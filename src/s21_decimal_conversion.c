#include "s21_decimal.h"

#define S21_OVERFLOW 1

int s21_from_int_to_decimal(int src, s21_decimal *dst) {
  for (int i = 0; i < 4; i++) dst->bits[i] = 0;
  dst->bits[3] = src & 0x80000000;

  dst->bits[0] = (abs(src));
  return 0;
}

int s21_from_decimal_to_int(s21_decimal src, int *dst) {
  int status = S21_OK;
  *dst = 0;

  s21_truncate(src, &src);
  if (src.bits[2] || src.bits[1] || src.bits[0] > 0x7fffffff) {
    status = S21_OVERFLOW;
  }
  *dst = (src.bits[3] & 0x80000000) ? -(src.bits[0] & 0x7fffffff)
                                    : src.bits[0] & 0x7fffffff;

  return status;
}

int s21_from_decimal_to_float(s21_decimal src, float *dst) {
  double tmp = 0;
  int scale = s21_get_scale(src);

  for (int i = 0; i < 96; i++) {
    tmp *= 2;
    if (s21_get_bit(src, 95 - i)) tmp += 1;
  }
  while (scale > 0) {
    tmp /= 10;
    scale--;
  }
  if (s21_get_sign(src)) tmp *= -1;
  *dst = (float)tmp;
  return 0;
}

int s21_from_float_to_decimal(float src, s21_decimal *dst) {
  int result = 0;
  for (int i = 0; i < 4; i++) {
    dst->bits[i] = 0;
  }
  if ((src != src) | (fabsf(src) > 7.922816e28) | (fabsf(src) == INFINITY) |
      (fabsf(src) < 1e-28)) {
    if (fabsf(src) != 0) {
      result = 1;
    }
  } else {
    char flts[64];
    sprintf(flts, "%.6e", src);
    int sign_int = (src > 0 ? 0 : 1);
    src = fabsf(src);
    char numb[64];
    int j = 0;
    for (unsigned long int i = 0; i < strlen(flts); i++) {
      if (flts[i] == 'e') {
        numb[j] = '\0';
        break;
      }
      if (flts[i] != 46) {
        numb[j] = flts[i];
        j++;
      }
    }
    int _exp10 = 0;
    int _mantissa = 0;
    int tmp = 0;
    sscanf(numb, "%d", &_mantissa);
    sscanf(flts, "%d.%de%d", &tmp, &tmp, &_exp10);
    dst->bits[0] = abs(_mantissa);
    _exp10 = 6 - _exp10;
    while (_exp10 < 0) {
      // Shift digits left by one place
      for (int i = 3; i > 0; i--) {
        dst->bits[i] = (dst->bits[i] << 1) | (dst->bits[i - 1] >> 31);
      }
      dst->bits[0] <<= 1;
      _exp10++;
    }
    if (sign_int) {
      dst->bits[3] = 0x80000000;
    }
    s21_set_scale(dst, _exp10);
  }
  return result;
}