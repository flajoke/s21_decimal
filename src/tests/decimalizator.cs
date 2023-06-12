using System;
using System.IO;
using System.Diagnostics;

class Decimalizator
{
  public static bool silence = true;
  public static void Main()
  {
    String testname = "s21_decimal";
    Console.WriteLine("DECIMALIZATOR 2000: {0}", testname);

    s21_add();
    s21_sub();
    s21_mul();

    s21_is_equal();
    s21_is_not_equal();
    s21_is_greater();
    s21_is_greater_or_equal();
    s21_is_less();
    s21_is_less_or_equal();

    s21_from_int_to_decimal();
    s21_from_decimal_to_int();

    s21_from_decimal_to_float();
    s21_from_float_to_decimal();

    s21_negate();
    s21_truncate();
    s21_floor();
    s21_round();


    s21_div();
    s21_mod();
  }


  public static void s21_add()
  {

    int ok = 0;
    int all = 0;
    String testname = "s21_add";
    Console.WriteLine("TEST: {0}", testname);

    BinaryReader reader_input = new BinaryReader(File.Open(testname + ".input", FileMode.Open));
    BinaryReader reader_output = new BinaryReader(File.Open(testname + ".output", FileMode.Open));


    while (reader_output.BaseStream.Position != reader_output.BaseStream.Length)
    {
      decimal op1 = reader_input.ReadDecimal();
      decimal op2 = reader_input.ReadDecimal();
      reader_input.ReadDecimal();

      decimal result = reader_output.ReadDecimal();
      all++;
      if (result == op1 + op2)
      {
        ok++;
        if (!silence)
        {
          Console.WriteLine("OK: in {0}: {1} + ({2}) = {3}", testname, op1, op2, result);
        }

      }
      else
      {
        //if (!silence)
        { Console.WriteLine("ERROR: in {0}: {1} + ({2}) = {3} (!= {4} (~({5})))", testname, op1, op2, result, op1 + op2, result - (op1 + op2)); }
      }


    }
    Console.WriteLine("TOTAL: {0} OK: {1}: ERROR: {2}", all, ok, all - ok);
    reader_output.Close(); reader_input.Close();

  }
  public static void s21_sub()
  {
    String testname = "s21_sub";
    Console.WriteLine("TEST: {0}", testname);
    int ok = 0;
    int all = 0;

    BinaryReader reader_input = new BinaryReader(File.Open(testname + ".input", FileMode.Open));
    BinaryReader reader_output = new BinaryReader(File.Open(testname + ".output", FileMode.Open));


    while (reader_output.BaseStream.Position != reader_output.BaseStream.Length)
    {
      decimal op1 = reader_input.ReadDecimal();
      decimal op2 = reader_input.ReadDecimal();
      reader_input.ReadDecimal();

      decimal result = reader_output.ReadDecimal();
      all++;
      if (result == op1 - op2)
      {
        ok++;
        if (!silence)
        {
          Console.WriteLine("OK: in {0}: {1} - ({2}) = {3}", testname, op1, op2, result);
        }

      }
      else
      {
        //if (!silence)
        Console.WriteLine("ERROR: in {0}: {1} - ({2}) = {3} (!= {4} (~({5})))", testname, op1, op2, result, op1 - op2, result - (op1 - op2));
      }


    }
    Console.WriteLine("TOTAL: {0} OK: {1}: ERROR: {2}", all, ok, all - ok);
    reader_output.Close(); reader_input.Close();

  }
  public static void s21_mul()
  {
    int ok = 0;
    int all = 0;
    String testname = "s21_mul";
    Console.WriteLine("TEST: {0}", testname);

    BinaryReader reader_input = new BinaryReader(File.Open(testname + ".input", FileMode.Open));
    BinaryReader reader_output = new BinaryReader(File.Open(testname + ".output", FileMode.Open));


    while (reader_output.BaseStream.Position != reader_output.BaseStream.Length)
    {
      decimal op1 = reader_input.ReadDecimal();
      decimal op2 = reader_input.ReadDecimal();
      reader_input.ReadDecimal();

      decimal result = reader_output.ReadDecimal();
      all++;
      if (result == op1 * op2)
      {
        ok++;
        if (!silence)
        {
          Console.WriteLine("OK: in {0}: {1} * ({2}) = {3}", testname, op1, op2, result);
        }

      }
      else
      {

        Console.WriteLine("ERROR: in {0}: {1} * ({2}) = {3} (!= {4} (~({5})))", testname, op1, op2, result, op1 * op2, result - (op1 * op2));
      }


    }
    Console.WriteLine("TOTAL: {0} OK: {1}: ERROR: {2}", all, ok, all - ok);
    reader_output.Close(); reader_input.Close();


  }
  public static void s21_div()
  {
    String testname = "s21_div";
    Console.WriteLine("TEST: {0}", testname);
    int ok = 0;
    int all = 0;

    BinaryReader reader_input = new BinaryReader(File.Open(testname + ".input", FileMode.Open));
    BinaryReader reader_output = new BinaryReader(File.Open(testname + ".output", FileMode.Open));


    while (reader_output.BaseStream.Position != reader_output.BaseStream.Length)
    {
      decimal op1 = reader_input.ReadDecimal();
      decimal op2 = reader_input.ReadDecimal();
      reader_input.ReadDecimal();

      decimal result = reader_output.ReadDecimal();
      all++;
      if (result == op1 / op2)
      {
        ok++;
        if (!silence)
        {
          Console.WriteLine("OK: in {0}: {1} / ({2}) = {3}", testname, op1, op2, result);
        }

      }
      else
      {

        Console.WriteLine("ERROR: in {0}: {1} / ({2}) = {3} (!= {4})", testname, op1, op2, result, op1 / op2);
      }


    }
    Console.WriteLine("TOTAL: {0} OK: {1}: ERROR: {2}", all, ok, all - ok);
    reader_output.Close(); reader_input.Close();


  }
  public static void s21_mod()
  {
    int ok = 0;
    int all = 0;
    String testname = "s21_mod";
    Console.WriteLine("TEST: {0}", testname);

    BinaryReader reader_input = new BinaryReader(File.Open(testname + ".input", FileMode.Open));
    BinaryReader reader_output = new BinaryReader(File.Open(testname + ".output", FileMode.Open));


    while (reader_output.BaseStream.Position != reader_output.BaseStream.Length)
    {
      decimal op1 = reader_input.ReadDecimal();
      decimal op2 = reader_input.ReadDecimal();
      reader_input.ReadDecimal();

      decimal result = reader_output.ReadDecimal();

      if (result == op1 % op2)

      {
        ok++;
        if (!silence)
        {
          Console.WriteLine("OK: in {0}: {1} % {2} = {3}", testname, op1, op2, result);
        }

      }
      else
      {

        Console.WriteLine("ERROR: in {0}: {1} % {2} = {3} (!= {4})", testname, op1, op2, result, op1 % op2);
      }
      all++;
    }

    reader_output.Close(); reader_input.Close();
    Console.WriteLine("TOTAL: {0} OK: {1}: ERROR: {2}", all, ok, all - ok);

  }

  public static void s21_is_equal()
  {
    int ok = 0;
    int all = 0;
    String testname = "s21_is_equal";

    Console.WriteLine("TEST: {0}", testname);

    BinaryReader reader_input = new BinaryReader(File.Open(testname + ".input", FileMode.Open));
    BinaryReader reader_output = new BinaryReader(File.Open(testname + ".output", FileMode.Open));


    while (reader_output.BaseStream.Position != reader_output.BaseStream.Length)
    {
      all++;
      decimal op1 = reader_input.ReadDecimal();
      decimal op2 = reader_input.ReadDecimal();
      Int32 eq = reader_input.ReadInt32();

      Int32 result = reader_output.ReadInt32();



      if (((op1 == op2) ? 1 : 0) == (result))
      {
        ok++;
        if (!silence)
        {
          Console.WriteLine("OK: in {0}: {1} == {2} = {3}", testname, op1, op2, result);
        }

      }
      else
      {

        Console.WriteLine("ERROR: in {0}: {1} == {2} = {3} (!= {4})", testname, op1, op2, (result == 1 ? true : false), op1 == op2);
      }
    }
    Console.WriteLine("TOTAL: {0} OK: {1}: ERROR: {2}", all, ok, all - ok);
    reader_output.Close(); reader_input.Close();

  }
  public static void s21_is_not_equal()
  {
    int ok = 0;
    int all = 0;
    String testname = "s21_is_not_equal";

    Console.WriteLine("TEST: {0}", testname);

    BinaryReader reader_input = new BinaryReader(File.Open(testname + ".input", FileMode.Open));
    BinaryReader reader_output = new BinaryReader(File.Open(testname + ".output", FileMode.Open));


    while (reader_output.BaseStream.Position != reader_output.BaseStream.Length)
    {
      all++;
      decimal op1 = reader_input.ReadDecimal();
      decimal op2 = reader_input.ReadDecimal();
      Int32 eq = reader_input.ReadInt32();

      Int32 result = reader_output.ReadInt32();



      if (((op1 != op2) ? 1 : 0) == (result))
      {
        ok++;
        if (!silence)
        {
          Console.WriteLine("OK: in {0}: {1} != {2}", testname, op1, op2, result);
        }

      }
      else
      {

        Console.WriteLine("ERROR: in {0}: {1} != {2} = {3} (!= {4})", testname, op1, op2, (result == 1 ? true : false), op1 != op2);
      }
    }
    Console.WriteLine("TOTAL: {0} OK: {1}: ERROR: {2}", all, ok, all - ok);
    reader_output.Close(); reader_input.Close();

  }
  public static void s21_is_greater()
  {
    int ok = 0;
    int all = 0;
    String testname = "s21_is_greater";
    Console.WriteLine("TEST: {0}", testname);

    BinaryReader reader_input = new BinaryReader(File.Open(testname + ".input", FileMode.Open));
    BinaryReader reader_output = new BinaryReader(File.Open(testname + ".output", FileMode.Open));


    while (reader_output.BaseStream.Position != reader_output.BaseStream.Length)
    {
      all++;
      decimal op1 = reader_input.ReadDecimal();
      decimal op2 = reader_input.ReadDecimal();
      Int32 eq = reader_input.ReadInt32();

      Int32 result = reader_output.ReadInt32();



      if (((op1 > op2) ? 1 : 0) == (result))
      {
        ok++;
        if (!silence)
        {
          Console.WriteLine("OK: in {0}: {1} > {2} = {3}", testname, op1, op2, result);
        }

      }
      else
      {

        Console.WriteLine("ERROR: in {0}: {1} > {2} = {3} (!= {4})", testname, op1, op2, (result == 1 ? true : false), op1 > op2);
      }
    }
    Console.WriteLine("TOTAL: {0} OK: {1}: ERROR: {2}", all, ok, all - ok);
    reader_output.Close(); reader_input.Close();

  }
  public static void s21_is_greater_or_equal()
  {
    int ok = 0;
    int all = 0;
    String testname = "s21_is_greater_or_equal";
    Console.WriteLine("TEST: {0}", testname);

    BinaryReader reader_input = new BinaryReader(File.Open(testname + ".input", FileMode.Open));
    BinaryReader reader_output = new BinaryReader(File.Open(testname + ".output", FileMode.Open));


    while (reader_output.BaseStream.Position != reader_output.BaseStream.Length)
    {
      all++;
      decimal op1 = reader_input.ReadDecimal();
      decimal op2 = reader_input.ReadDecimal();
      Int32 eq = reader_input.ReadInt32();

      Int32 result = reader_output.ReadInt32();



      if (((op1 >= op2) ? 1 : 0) == (result))
      {
        ok++;
        if (!silence)
        {
          Console.WriteLine("OK: in {0}: {1} >= {2} = {3}", testname, op1, op2, result);
        }

      }
      else
      {

        Console.WriteLine("ERROR: in {0}: {1} >= {2} = {3} (!= {4})", testname, op1, op2, (result == 1 ? true : false), op1 >= op2);
      }
    }
    Console.WriteLine("TOTAL: {0} OK: {1}: ERROR: {2}", all, ok, all - ok);
    reader_output.Close(); reader_input.Close();

  }
  public static void s21_is_less_or_equal()
  {
    int ok = 0;
    int all = 0;
    String testname = "s21_is_less_or_equal";
    Console.WriteLine("TEST: {0}", testname);

    BinaryReader reader_input = new BinaryReader(File.Open(testname + ".input", FileMode.Open));
    BinaryReader reader_output = new BinaryReader(File.Open(testname + ".output", FileMode.Open));


    while (reader_output.BaseStream.Position != reader_output.BaseStream.Length)
    {
      all++;
      decimal op1 = reader_input.ReadDecimal();
      decimal op2 = reader_input.ReadDecimal();
      Int32 eq = reader_input.ReadInt32();

      Int32 result = reader_output.ReadInt32();



      if (((op1 <= op2) ? 1 : 0) == (result))
      {
        ok++;
        if (!silence)
        {
          Console.WriteLine("OK: in {0}: {1} <= {2} = {3}", testname, op1, op2, result);
        }

      }
      else
      {

        Console.WriteLine("ERROR: in {0}: {1} <= {2} = {3} (!= {4})", testname, op1, op2, (result == 1 ? true : false), op1 <= op2);
      }
    }
    Console.WriteLine("TOTAL: {0} OK: {1}: ERROR: {2}", all, ok, all - ok);
    reader_output.Close(); reader_input.Close();

  }
  public static void s21_is_less()
  {
    int ok = 0;
    int all = 0;
    String testname = "s21_is_less";
    Console.WriteLine("TEST: {0}", testname);

    BinaryReader reader_input = new BinaryReader(File.Open(testname + ".input", FileMode.Open));
    BinaryReader reader_output = new BinaryReader(File.Open(testname + ".output", FileMode.Open));


    while (reader_output.BaseStream.Position != reader_output.BaseStream.Length)
    {
      all++;
      decimal op1 = reader_input.ReadDecimal();
      decimal op2 = reader_input.ReadDecimal();
      Int32 eq = reader_input.ReadInt32();

      Int32 result = reader_output.ReadInt32();



      if (((op1 < op2) ? 1 : 0) == (result))
      {
        ok++;
        if (!silence)
        {
          Console.WriteLine("OK: in {0}: {1} < {2} = {3}", testname, op1, op2, result);
        }

      }
      else
      {

        Console.WriteLine("ERROR: in {0}: {1} < {2} = {3} (!= {4})", testname, op1, op2, (result == 1 ? true : false), op1 < op2);
      }
    }
    Console.WriteLine("TOTAL: {0} OK: {1}: ERROR: {2}", all, ok, all - ok);
    reader_output.Close(); reader_input.Close();

  }


  public static void s21_floor()
  {

    int all = 0;
    int ok = 0;

    String testname = "s21_floor";
    Console.WriteLine("TEST: {0}", testname);

    BinaryReader reader_input = new BinaryReader(File.Open(testname + ".input", FileMode.Open));
    BinaryReader reader_output = new BinaryReader(File.Open(testname + ".output", FileMode.Open));


    while (reader_output.BaseStream.Position != reader_output.BaseStream.Length)
    {
      all++;
      decimal op = reader_input.ReadDecimal();
      reader_input.ReadDecimal();

      decimal result = reader_output.ReadDecimal();

      if (result == decimal.Floor(op))
      {
        ok++;
        if (!silence)
        {

          //Console.WriteLine("OK"); 
          Console.WriteLine("OK: in {0}: Floor({1}) = {2}", testname, op, result);
        }

      }
      else
      {

        Console.WriteLine("ERROR: in {0}: Floor({1}) = {2} (!= {3})", testname, op, result, decimal.Floor(op));
      }
    }
    Console.WriteLine("TOTAL: {0} OK: {1}: ERROR: {2}", all, ok, all - ok);

    reader_output.Close(); reader_input.Close();
  }
  public static void s21_round()
  {
    String testname = "s21_round";
    Console.WriteLine("TEST: {0}", testname);

    int all = 0;
    int ok = 0;

    BinaryReader reader_input = new BinaryReader(File.Open(testname + ".input", FileMode.Open));
    BinaryReader reader_output = new BinaryReader(File.Open(testname + ".output", FileMode.Open));


    while (reader_output.BaseStream.Position != reader_output.BaseStream.Length)
    {
      all++;
      decimal op = reader_input.ReadDecimal();
      reader_input.ReadDecimal();

      decimal result = reader_output.ReadDecimal();

      if (result == decimal.Round(op))
      {
        ok++;
        if (!silence)
        {
          //Console.WriteLine("OK"); 
          Console.WriteLine("OK: in {0}: Round({1}) = {2}", testname, op, result);
        }

      }
      else
      {

        Console.WriteLine("ERROR: in {0}: Round({1}) = {2} (!= {3})", testname, op, result, decimal.Round(op));
      }
    }
    Console.WriteLine("TOTAL: {0} OK: {1}: ERROR: {2}", all, ok, all - ok);


    reader_output.Close(); reader_input.Close();
  }
  public static void s21_negate()
  {
    int ok = 0;
    int all = 0;
    String testname = "s21_negate";
    Console.WriteLine("TEST: {0}", testname);

    BinaryReader reader_input = new BinaryReader(File.Open(testname + ".input", FileMode.Open));
    BinaryReader reader_output = new BinaryReader(File.Open(testname + ".output", FileMode.Open));


    while (reader_output.BaseStream.Position != reader_output.BaseStream.Length)
    {
      decimal op = reader_input.ReadDecimal();
      reader_input.ReadDecimal();

      decimal result = reader_output.ReadDecimal();

      if (result == decimal.Negate(op))
      {
        ok++;
        if (!silence)
        {
          //Console.WriteLine("OK"); 
          Console.WriteLine("OK: in {0}: Negate({1}) = {2}", testname, op, result);
        }

      }
      else
      {

        Console.WriteLine("ERROR: in {0}: Negate({1}) = {2} (!= {3})", testname, op, result, decimal.Negate(op));
      }
      all++;
    }
    Console.WriteLine("TOTAL: {0} OK: {1}: ERROR: {2}", all, ok, all - ok);
    reader_output.Close(); reader_input.Close();
  }
  public static void s21_truncate()
  {
    String testname = "s21_truncate";

    Console.WriteLine("TEST: {0}", testname);

    BinaryReader reader_input = new BinaryReader(File.Open(testname + ".input", FileMode.Open));
    BinaryReader reader_output = new BinaryReader(File.Open(testname + ".output", FileMode.Open));

    int all = 0;
    int ok = 0;
    while (reader_output.BaseStream.Position != reader_output.BaseStream.Length)
    {

      decimal op = reader_input.ReadDecimal();
      reader_input.ReadDecimal();

      decimal result = reader_output.ReadDecimal();

      if (result == decimal.Truncate(op))
      {
        ok++;
        if (!silence)
        {
          //Console.WriteLine("OK"); 
          Console.WriteLine("OK: in {0}: Truncate({1}) = {2}", testname, op, result);
        }

      }
      else
      {

        Console.WriteLine("ERROR: in {0}: Truncate({1}) = {2} (!= {3})", testname, op, result, decimal.Truncate(op));
      }
      all++;
    }
    Console.WriteLine("TOTAL: {0} OK: {1}: ERROR: {2}", all, ok, all - ok);
    reader_output.Close(); reader_input.Close();
  }


  public static void s21_from_int_to_decimal()
  {
    int ok = 0;
    int all = 0;
    String testname = "s21_from_int_to_decimal";
    Console.WriteLine("TEST: {0}", testname);

    BinaryReader reader_input = new BinaryReader(File.Open(testname + ".input", FileMode.Open));
    BinaryReader reader_output = new BinaryReader(File.Open(testname + ".output", FileMode.Open));


    while (reader_output.BaseStream.Position != reader_output.BaseStream.Length)
    {

      Int32 op1 = reader_input.ReadInt32();
      decimal op2 = reader_input.ReadDecimal();
      decimal result = reader_output.ReadDecimal();



      if (op2 == result)
      {
        ok++;
        if (!silence)
        {
          Console.WriteLine("OK: in {0}: {1} == {2}", testname, op1, op2);
        }

      }
      else
      {

        Console.WriteLine("ERROR: in {0}: {1} == {2} (!= {3})", testname, result, op2, ((decimal)op1));
      }
      all++;
    }
    Console.WriteLine("TOTAL: {0} OK: {1}: ERROR: {2}", all, ok, all - ok);
    reader_output.Close(); reader_input.Close();

  }
  public static void s21_from_decimal_to_int()
  {
    int ok = 0;
    int all = 0;
    String testname = "s21_from_decimal_to_int";
    Console.WriteLine("TEST: {0}", testname);

    BinaryReader reader_input = new BinaryReader(File.Open(testname + ".input", FileMode.Open));
    BinaryReader reader_output = new BinaryReader(File.Open(testname + ".output", FileMode.Open));


    while ((reader_output.BaseStream.Position != reader_output.BaseStream.Length) && (reader_input.BaseStream.Position != reader_input.BaseStream.Length))
    {
      all++;
      decimal op1 = reader_input.ReadDecimal();
      Int32 op2 = reader_input.ReadInt32();
      Int32 status = reader_output.ReadInt32();
      Int32 result = reader_output.ReadInt32();


      try
      {
        if ((Int32)op1 == result)
        {
          ok++;
          if (!silence)
          {
            Console.WriteLine("OK: in {0}: {1} == {2}", testname, result, op2);
          }

        }
        else
        {

          Console.WriteLine("ERROR: in {0}: {1} == {2} (!= {3}) {4}", testname, result, op2, (Int32)op1, op1);
        }
      }
      catch (System.Exception)
      {
        if (status == 1)
        {
          ok++;
        }
        throw;
      }
    }
    Console.WriteLine("TOTAL: {0} OK: {1}: ERROR: {2}", all, ok, all - ok);
    reader_output.Close(); reader_input.Close();

  }

  public static void s21_from_float_to_decimal()
  {
    int ok = 0;
    int all = 0;
    String testname = "s21_from_float_to_decimal";
    Console.WriteLine("TEST: {0}", testname);

    BinaryReader reader_input = new BinaryReader(File.Open(testname + ".input", FileMode.Open));
    BinaryReader reader_output = new BinaryReader(File.Open(testname + ".output", FileMode.Open));


    while (reader_output.BaseStream.Position != reader_output.BaseStream.Length)
    {

      float op1 = reader_input.ReadSingle();
      decimal op2 = reader_input.ReadDecimal();
      decimal result = reader_output.ReadDecimal();



      if (op2 == result)
      {
        ok++;
        if (!silence)
        {
          Console.WriteLine("OK: in {0}: {1} == {2}", testname, op1, op2);
        }

      }
      else
      {

        Console.WriteLine("ERROR: in {0}: {1} != {2} (!= {3})", testname, result, op2, ((decimal)op1));
      }
      all++;
    }
    Console.WriteLine("TOTAL: {0} OK: {1}: ERROR: {2}", all, ok, all - ok);
    reader_output.Close(); reader_input.Close();

  }
  public static void s21_from_decimal_to_float()
  {
    int ok = 0;
    int all = 0;
    String testname = "s21_from_decimal_to_float";
    Console.WriteLine("TEST: {0}", testname);

    BinaryReader reader_input = new BinaryReader(File.Open(testname + ".input", FileMode.Open));
    BinaryReader reader_output = new BinaryReader(File.Open(testname + ".output", FileMode.Open));


    while ((reader_output.BaseStream.Position != reader_output.BaseStream.Length) && (reader_input.BaseStream.Position != reader_input.BaseStream.Length))
    {
      all++;
      decimal op1 = reader_input.ReadDecimal();
      float op2 = reader_input.ReadSingle();
      float status = reader_output.ReadSingle();
      float result = reader_output.ReadSingle();


      try
      {
        if (Math.Abs((float)op1 - result) < 1e-6)
        {
          ok++;
          if (!silence)
          {
            Console.WriteLine("OK: in {0}: {1} == {2}", testname, op1, op2);
          }

        }
        else
        {

          Console.WriteLine("ERROR: in {0}: {1} != {2}", testname, (float)op1, result);
        }
      }
      catch (System.Exception)
      {
        if (status == 1)
        {
          ok++;
        }
        throw;
      }
    }
    Console.WriteLine("TOTAL: {0} OK: {1}: ERROR: {2}", all, ok, all - ok);
    reader_output.Close(); reader_input.Close();

  }

}
