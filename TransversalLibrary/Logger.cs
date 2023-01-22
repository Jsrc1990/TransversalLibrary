using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.CompilerServices;

namespace TransversalLibrary
{
    /// <summary>
    /// Define la clase que gestiona el Log
    /// </summary>
    public static class Logger
    {
        /// <summary>
        /// Imprime el log
        /// </summary>
        /// <param name="ex">La excepción</param>
        /// <param name="name">El nombre de la función que invoca la excepción</param>
        public static void Log(Exception ex, [CallerMemberName] string name = "")
        {
            try
            {
                int? line = GetLine(ex);
                PrintException(ex, name);
                string path = $@"{Environment.CurrentDirectory}\Log.txt";
                File.AppendAllLines(path, new[] { "********************************** EXCEPTION: " + name });
                Console.WriteLine($"Error: {ex?.Message}, InnerException: {ex?.InnerException?.Message}, Line: {line}");
                File.AppendAllLines(path, new[] { "********************************** END EXCEPTION" + name });
            }
            catch (Exception exception)
            {
                PrintException(exception, name);
            }
        }

        /// <summary>
        /// Imprime el log
        /// </summary>
        /// <param name="message">El mensaje</param>
        /// <param name="name">El nombre de la función que invoca la excepción</param>
        public static void Log(string message, [CallerMemberName] string name = "")
        {
            try
            {
                Console.WriteLine("********************************** MESSAGE: " + name);
                Console.WriteLine($"{message}");
                Console.WriteLine("********************************** END MESSAGE");
                string path = $@"{Environment.CurrentDirectory}\Log.txt";
                File.AppendAllLines(path, new[] { $"{message}" });
            }
            catch (Exception exception)
            {
                PrintException(exception, name);
            }
        }

        /// <summary>
        /// Imprime la excepción
        /// </summary>
        /// <param name="exception">La excepción</param>
        /// <param name="name">El nombre de la función que invoca la excepción</param>
        private static void PrintException(Exception exception, [CallerMemberName] string name = "")
        {
            int? line = GetLine(exception);
            Console.WriteLine("********************************** EXCEPTION: " + name);
            Console.WriteLine($"Error: {exception?.Message}, InnerException: {exception?.InnerException?.Message}, Line: {line}");
            Console.WriteLine("********************************** END EXCEPTION");
        }

        /// <summary>
        /// Obtiene la linea de la excepción
        /// </summary>
        /// <param name="exception">La excepción</param>
        /// <returns>El número de linea de la excepción</returns>
        private static int? GetLine(Exception exception)
        {
            //Get stack trace for the exception with source file information
            StackTrace stackTrace = new StackTrace(exception, true);
            //Get the top stack frame
            StackFrame frame = stackTrace?.GetFrame(0);
            //Get the line number from the stack frame
            int? line = frame?.GetFileLineNumber();
            return line;
        }

        /// <summary>
        /// Elimina el Log
        /// </summary>
        public static void DeleteLog()
        {
            string path = $@"{Environment.CurrentDirectory}\Log.txt";
            if (File.Exists(path)) File.Delete(path);
        }
    }
}