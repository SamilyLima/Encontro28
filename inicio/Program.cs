using System;

namespace inicio
{
    class Program
    {
        static void Main(string[] args)
        {
            string situacaoFuncionario;
            string respostaSeNao;
            Console.WriteLine("Você está gostando de trabalhar aqui? (sim ou não)");
            situacaoFuncionario = Console.ReadLine();

            if(situacaoFuncionario.ToLower() == "sim")
            {
                Console.WriteLine("Que legal!");
            }

            else
            {
                if(situacaoFuncionario.ToLower() == "não")
                {
                    Console.WriteLine("Por quê?");
                    respostaSeNao = Console.ReadLine();
                    Console.WriteLine("A sua resposta é: " + respostaSeNao);                }
               
            }
        }
    }
}
