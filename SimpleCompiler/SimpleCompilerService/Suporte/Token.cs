﻿using System.ComponentModel;
using System.Reflection;

namespace SimpleCompilerService.Suporte
{
    public class Token<T>
    {
        #region 1. Propriedades e Construtores
        public T Lexema { get; set; }
        public Tipo Tipo { get; set; }
        public int Linha { get; set; }

        public Token(T lexema, Tipo tipo, int linha)
        {
            Lexema = lexema;
            Tipo = tipo;
            Linha = linha;
        }

        public Token()
        {

        }
        #endregion

        #region 2. Métodos Privados
        private string GetTagDescription()
        {
            FieldInfo fi = Tipo.GetType().GetField(Tipo.ToString());

            DescriptionAttribute[] attributes =
                (DescriptionAttribute[])fi.GetCustomAttributes(
                typeof(DescriptionAttribute),
                false);

            if (attributes != null &&
                attributes.Length > 0)
                return attributes[0].Description;
            else
                return Tipo.ToString();
        }
        #endregion

        #region 3. Sobrecarga de Métodos
        public override string ToString()
        {
            return "Lexema: " + Lexema + "\nTipo:" + GetTagDescription() + "\nLinha:" + Linha;
        }
        #endregion
    }
}
