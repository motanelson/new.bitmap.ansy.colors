using System;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;
//dotnet add package SixLabors.ImageSharp
class Program
{
    static readonly Rgba32[] VgaColors = new Rgba32[]
    {
        new Rgba32(0x00, 0x00, 0x00), // 0 - Preto
        new Rgba32(0xAA, 0x00, 0x00), // 1 - Vermelho
        new Rgba32(0x00, 0xAA, 0x00), // 2 - Verde
        new Rgba32(0xAA, 0x55, 0x00), // 3 - Castanho
        new Rgba32(0x00, 0x00, 0xAA), // 4 - Azul
        new Rgba32(0xAA, 0x00, 0xAA), // 5 - Magenta
        new Rgba32(0x00, 0xAA, 0xAA), // 6 - Ciano
        new Rgba32(0xAA, 0xAA, 0xAA), // 7 - Cinzento claro
        new Rgba32(0x55, 0x55, 0x55), // 8 - Cinzento escuro
        new Rgba32(0xFF, 0x55, 0x55), // 9 - Vermelho claro
        new Rgba32(0x55, 0xFF, 0x55), // 10 - Verde claro
        new Rgba32(0xFF, 0xFF, 0x55), // 11 - Amarelo
        new Rgba32(0x55, 0x55, 0xFF), // 12 - Azul claro
        new Rgba32(0xFF, 0x55, 0xFF), // 13 - Magenta claro
        new Rgba32(0x55, 0xFF, 0xFF), // 14 - Ciano claro
        new Rgba32(0xFF, 0xFF, 0xFF)  // 15 - Branco
    };

    static void Main()
    {
        Console.ForegroundColor = ConsoleColor.Black;
        Console.BackgroundColor = ConsoleColor.DarkYellow;
        try
        {
            Console.Write("Introduz a largura: ");
            int largura = int.Parse(Console.ReadLine());

            Console.Write("Introduz a altura: ");
            int altura = int.Parse(Console.ReadLine());

            Console.Write("Introduz a cor VGA (0-15): ");
            int cor = int.Parse(Console.ReadLine());

            if (cor < 0 || cor > 15 || largura <= 0 || altura <= 0)
            {
                Console.WriteLine("Erro: entrada inválida.");
                return;
            }

            var corFundo = VgaColors[cor];

            using (var imagem = new Image<Rgba32>(largura, altura))
            {
                imagem.Mutate(ctx => ctx.BackgroundColor(corFundo));
                imagem.SaveAsBmp("new.bmp");
            }

            Console.WriteLine("Imagem 'new.bmp' criada com sucesso.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Erro: " + ex.Message);
        }
    }
}

