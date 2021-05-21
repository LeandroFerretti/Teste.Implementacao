using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace Teste.Implementacao
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();

            Console.WriteLine();
            Console.WriteLine("-------------------------------------------");
            Console.WriteLine(string.Format("-- {0} ", "{Leandro Ferretti}"));
            Console.WriteLine("-------------------------------------------");
            Console.WriteLine();

            Executar();

            stopwatch.Stop();

            Console.WriteLine();
            Console.WriteLine("-------------------------------------------");
            Console.WriteLine(string.Format("-- PROGRAMA FINALIZADO EM {0}ms", stopwatch.ElapsedMilliseconds));
            Console.WriteLine("-------------------------------------------");
            Console.WriteLine();
            Console.ReadKey();
        }

        private static void Executar()
        {
            var texto = PegarTextoDeUmArquivo();
            var lista = ConvertToList(texto);

            MostrarFormatado(lista);

        }

        private static void MostrarFormatado(string[] lista)
        {
            var contador = 0;
            foreach (var valor in lista)
            {
                if (IsFixo(valor))
                    lista[contador] = "RES: " + FormatarTelefoneFixo(valor);
                else if (IsMovel(valor))
                    lista[contador] = "MOB: " + FormatarTelefoneMovel(valor);
                else if (IsSUP(valor))
                    lista[contador] = "SUP: " + valor;
                else if (IsNotGeografico(valor))
                    lista[contador] = "NNG: " + FormatarTelefoneNaoGeografico(valor);
                else if (IsPrestadoraServicos(valor))
                    lista[contador] = FormatarTelefonePrestadoraServicos(valor);
                else
                    lista[contador] = $"Número de telefone não identificado: {valor}";

                contador++;

            }
            foreach (var list in lista)
                Console.WriteLine(list);

            Console.ReadLine();

        }


        private static bool IsFixo(string valor)
        {
            List<int> IniciaisTelefoneFixo = new List<int> { 2, 3, 4, 5 };

            if (valor.Length < 8)
                return false;

            if (int.Parse(valor.Substring(0, 2)) == 55)
                if (int.Parse(valor.Substring(2, 3)) == 047)
                    if (IniciaisTelefoneFixo.Contains(int.Parse(valor.Substring(3, 1))))
                        return true;

            if (int.Parse(valor.Substring(0, 2)) == 55)
                if (int.Parse(valor.Substring(2, 2)) == 47)
                    if (IniciaisTelefoneFixo.Contains(int.Parse(valor.Substring(4, 1))))
                        return true;

            if (int.Parse(valor.Substring(0, 2)) == 47)
                if (IniciaisTelefoneFixo.Contains(int.Parse(valor.Substring(2, 1))))
                    return true;

            if (int.Parse(valor.Substring(0, 3)) == 047)
                if (IniciaisTelefoneFixo.Contains(int.Parse(valor.Substring(3, 1))))
                    return true;
            if (valor.Length == 8)
                if (IniciaisTelefoneFixo.Contains(int.Parse(valor.Substring(0, 1))))
                    return true;

            return false;
        }
        private static bool IsMovel(string valor)
        {
            List<int> IniciaisTelefoneMovel = new List<int> { 7, 8, 9 };

            if (valor.Length < 8)
                return false;

            List<int> IniciaisTelefoneFixo = new List<int> { 2, 3, 4, 5 };
            if (int.Parse(valor.Substring(0, 2)) == 55)
                if (int.Parse(valor.Substring(2, 3)) == 047)
                    if (IniciaisTelefoneMovel.Contains(int.Parse(valor.Substring(3, 1))))
                        return true;

            if (int.Parse(valor.Substring(0, 2)) == 55)
                if (int.Parse(valor.Substring(2, 2)) == 47)
                    if (IniciaisTelefoneMovel.Contains(int.Parse(valor.Substring(4, 1))))
                        return true;

            if (int.Parse(valor.Substring(0, 2)) == 47)
                if (IniciaisTelefoneMovel.Contains(int.Parse(valor.Substring(2, 1))))
                    return true;

            if (int.Parse(valor.Substring(0, 3)) == 047)
                if (IniciaisTelefoneMovel.Contains(int.Parse(valor.Substring(3, 1))))
                    return true;
            if (valor.Length == 8 || valor.Length == 9)
                if (IniciaisTelefoneMovel.Contains(int.Parse(valor.Substring(0, 1))))
                    return true;

            return false;
        }
        private static bool IsSUP(string valor)
        {
            if (valor.Length == 3)
                return true;

            return false;
        }
        private static bool IsNotGeografico(string valor)
        {
            if (valor.Substring(0, 4) == "0800" || valor.Substring(0, 4) == "0500")
                return true;

            return false;
        }
        private static bool IsPrestadoraServicos(string valor)
        {
            List<int> prefixoPrestadoraServico = new List<int> { 103, 105, 106 };

            if (prefixoPrestadoraServico.Contains(int.Parse(valor.Substring(0, 3))))
                return true;

            return false;
        }

        private static string FormatarTelefoneFixo(string valor)
        {
            if (valor.Length == 8)
                return String.Format("{0:####-####}", long.Parse(valor));
            if (valor.Length == 10)
                return String.Format("{0:(##) ####-####}", long.Parse(valor));
            if (valor.Length == 11)
                return String.Format("{0:(###) ####-####}", long.Parse(valor));
            if (valor.Length == 12)
                return String.Format("{0:+## (##) ####-####}", long.Parse(valor));
            if (valor.Length == 13)
                return String.Format("{0:+## (###) ####-####}", long.Parse(valor));

            return string.Empty;
        }
        private static string FormatarTelefoneMovel(string valor)
        {
            if (valor.Substring(0, 1) == "0")
                valor = valor.Substring(1, valor.Length - 1);

            if (valor.Length == 8)
                return String.Format("{0:####-####}", long.Parse(valor));
            if (valor.Length == 9)
                return String.Format("{0:# ####-####}", long.Parse(valor));
            if (valor.Length == 10)
                return String.Format("{0:(##) ####-####}", long.Parse(valor));
            if (valor.Length == 11)
                return String.Format("{0:(##) # ####-####}", long.Parse(valor));
            if (valor.Length == 12)
                return String.Format("{0:+## (##) ####-####}", long.Parse(valor));
            if (valor.Length == 13)
                return String.Format("{0:+## (##) # ####-####}", long.Parse(valor));

            return string.Empty;
        }
        private static string FormatarTelefoneNaoGeografico(string valor)
        {

            return String.Format("{0:#### ### ####}", long.Parse(valor));

        }
        private static string FormatarTelefonePrestadoraServicos(string valor)
        {
            if (valor.Substring(0, 3) == "103")
                return $"ETM: {valor.Substring(0, 3)}+{valor.Substring(3, 2)}";
            if (valor.Substring(0, 3) == "105")
                return "ETM: " + valor;
            if (valor.Substring(0, 3) == "106")
                return "ETV: " + valor;

            return string.Empty;
        }


        private static string PegarTextoDeUmArquivo() =>
             File.ReadAllText(@"Arquivos\input.4.in");

        private static string[] ConvertToList(string texto)
        {
            string textoNecessario = texto.Substring(0, texto.IndexOf("\r\n\r\n"));
            return textoNecessario.Split("\r\n");
        }
    }
}