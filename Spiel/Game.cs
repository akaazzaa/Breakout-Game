using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace Spiel
{
    public class Game
    {
        RenderWindow _window;
        uint _frames;
        uint _wWidth, _wHeight;
        bool _isRunning = true;

        public Game() 
        {
            Init();
        }

        void Init()
        {
            _wWidth = 720;
            _wHeight = 720;
            _frames = 60;

            _window = new RenderWindow(new VideoMode(_wWidth, _wHeight), "SFML GameTEst", Styles.Default);
            _window.SetFramerateLimit(_frames);
            _window.KeyPressed += new EventHandler<KeyEventArgs>(OnKeyPressed);
            _window.KeyReleased += new EventHandler<KeyEventArgs>(OnKeyReleased);
            _window.Closed += new EventHandler(OnClose);


        }

        private void OnKeyPressed(object? sender, KeyEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void OnKeyReleased(object? sender, KeyEventArgs e)
        {
            throw new NotImplementedException();
        }

        void OnClose(object? sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        public void Run()
        {
            while (_isRunning)
            {

                _window.Clear();



                

               
               

                _window.Display();


            }
        }

    }

    
}
