#include "s21_decimal.h"

int s21_is_greater(s21_decimal value_1, s21_decimal value_2) {
  // If both values are null, they are not greater than each other
  if (s21_is_null(value_1) && s21_is_null(value_2)) {
    return 0;
  }

  // If the signs are different, the value with the greater sign is greater
  int sign_1 = s21_get_sign(value_1);
  int sign_2 = s21_get_sign(value_2);
  if (sign_1 > sign_2) {
    return 0;
  } else if (sign_1 < sign_2) {
    return 1;
  }

  // If the signs are the same, compare the absolute values
  int scale = s21_get_scale(value_1) >= s21_get_scale(value_2)
                  ? s21_get_scale(value_1)
                  : s21_get_scale(value_2);
  unsigned buf_1[6] = {0};
  unsigned buf_2[6] = {0};
  s21_to_scale(value_1, scale, buf_1, 6);
  s21_to_scale(value_2, scale, buf_2, 6);
  int abs_greater = s21_data_gt(buf_1, buf_2, 6);
  if (abs_greater) {
    return sign_1 ? 0 : 1;
  } else if (s21_is_equal(value_1, value_2)) {
    return 0;
  } else {
    return sign_1 ? 1 : 0;
  }
}
int s21_is_equal(s21_decimal value_1, s21_decimal value_2) {
  if (s21_is_null(value_1) && s21_is_null(value_2)) {
    return 1;  // both values are null, they are considered equal
  }

  // Compare the sign of the values
  if (s21_get_sign(value_1) != s21_get_sign(value_2)) {
    return 0;  // different signs, not equal
  }

  // Convert both values to a common scale and compare their data arrays
  int max_scale = s21_get_scale(value_1) > s21_get_scale(value_2)
                      ? s21_get_scale(value_1)
                      : s21_get_scale(value_2);
  unsigned buf1[6] = {0, 0, 0, 0, 0, 0};
  unsigned buf2[6] = {0, 0, 0, 0, 0, 0};
  s21_to_scale(value_1, max_scale, buf1, 6);
  s21_to_scale(value_2, max_scale, buf2, 6);
  for (int i = 0; i < 6; i++) {
    if (buf1[i] != buf2[i]) {
      return 0;  // different data, not equal
    }
  }

  // All checks passed, the values are equal
  return 1;
}
int s21_is_not_equal(s21_decimal value_1, s21_decimal value_2) {
  return !s21_is_equal(value_1, value_2);
}
int s21_is_greater_or_equal(s21_decimal value_1, s21_decimal value_2) {
  return s21_is_greater(value_1, value_2) || s21_is_equal(value_1, value_2);
}
int s21_is_less(s21_decimal value_1, s21_decimal value_2) {
  return s21_is_greater(value_2, value_1);
}
int s21_is_less_or_equal(s21_decimal value_1, s21_decimal value_2) {
  return s21_is_greater_or_equal(value_2, value_1);
}
