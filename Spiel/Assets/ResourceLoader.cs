
using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;


namespace Spiel.Assets
{
    public class ResourceLoader
    {
        private readonly string _resourcePath;

        private Dictionary<string, Texture> _textures;
        

        public List<string> fileNames;


        // Singleton-Instanz
        private static ResourceLoader _instance;
        public static ResourceLoader Instance => _instance ??= new ResourceLoader();

        // Privater Konstruktor für Singleton
        private ResourceLoader()
        {
            _resourcePath = "C:\\Users\\dgami\\source\\repos\\Spiel\\Spiel\\Assets\\Resources\\";
            _textures = new Dictionary<string, Texture>();
            fileNames = new List<string>();

            PreloadTextures();
        }

        // Methode zum Laden von Texturen aus Unterordnern
        public Texture LoadTexture(string relativeFilePath)
        {
           string filePath = Path.Combine(_resourcePath,"Sprites",relativeFilePath);
            
            if (File.Exists(filePath))
            {
                if (_textures.ContainsKey(relativeFilePath))
                {
                    return _textures[relativeFilePath];
                }

                var texture = new Texture(filePath);
                _textures[relativeFilePath] = texture;
                return texture;
            }
            else
            {
                Console.WriteLine($"Sprite not found at path: {filePath}");
                return null;
            }
        }

        // Methode zum Aktualisieren von Texturen in Unterordnern
        public void UpdateTexture(string relativeFilePath, string newFilePath)
        {
            if (File.Exists(newFilePath))
            {
                var texture = new Texture(newFilePath);
                _textures[relativeFilePath] = texture;

                // Optional: Kopiere die neue Datei ins Ressourcenverzeichnis
                string destPath = Path.Combine(_resourcePath, "Sprites", relativeFilePath);
                Directory.CreateDirectory(Path.GetDirectoryName(destPath));
                File.Copy(newFilePath, destPath, true);
            }
            else
            {
                Console.WriteLine($"New texture file not found at path: {newFilePath}");
            }
        }

        // Methode zum Vorladen aller Ressourcen (optional)
        public Dictionary<string, Texture> PreloadTextures()
        {
            var spritePath = Path.Combine(_resourcePath, "Sprites");
            foreach (var file in Directory.GetFiles(spritePath, "*.png", SearchOption.AllDirectories))
            {
                var relativePath = Path.GetRelativePath(spritePath, file);
                _textures[relativePath] = new Texture(file);
            }

            return _textures;
        }

        public Font FontLoder(string path)
        {
            string filePath = Path.Combine(_resourcePath, "Fonts", path);

            if (File.Exists(filePath))
            {
                return new Font(filePath);
            }
            else
            {
                Console.WriteLine($"Font not found at path: {filePath}");
                return null;
            }
        }

        public void LoadAllFileName()
        {
            var spritePath = Path.Combine(_resourcePath, "Sprites");

            foreach (var file in Directory.GetFiles(spritePath, "*.png", SearchOption.AllDirectories))
            {
                var relativePath = Path.GetRelativePath(spritePath, file);
                fileNames.Add(relativePath);
            }
        }
    }





}
