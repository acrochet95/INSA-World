using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using INSA_World;
using System.Timers;
using System.Windows.Threading;

namespace WPF_IHM.Pages
{
    /// <summary>
    /// Logique d'interaction pour Game.xaml
    /// </summary>
    public partial class Game : Page, ISwitchable
    {
        private const double OPACITY_HIGH = 1;
        private const double OPACITY_LOW = 0.2;

        private Engine engine = null;
        private Unit unitSelected;
        private List<Rectangle> possibleMoves_rects;
        private List<Image> unitsOnGrid;

        private String url_img_p1;
        private String url_img_p2;

        private bool victory;


        public Game()
        {
            InitializeComponent();

            this.engine = new Engine();
            this.engine.Initialize("demo", "testp1", "Centaure", "testp2", "Cerbère");

            url_img_p1 = RaceToUrl("Centaure");
            url_img_p2 = RaceToUrl("Cerbère");

            //engine.Game.Player1.Units[0].Position = new Position(5, 5);

            player1_race.Content = "Race : Cyclope";
            player2_race.Content = "Race : Cerbère";

            this.buildGrid();
        }

        public Game(string map, string name_p1, string race_p1, string name_p2, string race_p2)
        {
            InitializeComponent();

            this.engine = new Engine();
            this.engine.Initialize(map, name_p1, race_p1, name_p2, race_p2);

            url_img_p1 = RaceToUrl(race_p1);
            url_img_p2 = RaceToUrl(race_p2);

            player1_race.Content = "Race : " + race_p1;
            player2_race.Content = "Race : " + race_p2;

            this.buildGrid();
        }

        public Game(string name)
        {
            InitializeComponent();

            this.engine = new Engine(name);

            url_img_p1 = RaceToUrl(engine.Game.Player1.GetRace());
            url_img_p2 = RaceToUrl(engine.Game.Player2.GetRace());

            buildGrid();
        }

        private string RaceToUrl(string race)
        {
            string url = "cyclop";
            if (race.Equals("Cerbère"))
                url = "cerberus";
            else if(race.Equals("Centaure"))
                url = "centaur";

            return url;
        }
        private string RaceToUrl(Race race)
        {
            string url = "cyclop";
            if (race is Cerberus)
                url = "cerberus";
            else if (race is Centaur)
                url = "centaur";

            return url;
        }

        /* INTIALISATION */
        public void buildGrid()
        {
            victory = false;

            panel_turn.Visibility = Visibility.Visible;
            button_panel.Visibility = Visibility.Hidden;
            panel_message.Content = "C'est à " + engine.Game.currentPlayer.Name + " de commencer !";

            // Create a Timer with a Normal Priority
            DispatcherTimer _timer = new DispatcherTimer();

            // Set the Interval to 2 seconds
            _timer.Interval = TimeSpan.FromMilliseconds(4000);

            // Set the callback to just show the time ticking away
            // NOTE: We are using a control so this has to run on 
            // the UI thread
            _timer.Tick += new EventHandler(delegate(object s, EventArgs a)
            {
                if(!victory)
                    panel_turn.Visibility = Visibility.Hidden;
            });

            // Start the timer
            _timer.Start();

            panel_p1.Background = new ImageBrush(new BitmapImage(new Uri("../../Images/" + url_img_p1 + "_background.png", UriKind.Relative)));
            panel_p2.Background = new ImageBrush(new BitmapImage(new Uri("../../Images/" + url_img_p2 + "_background.png", UriKind.Relative)));

            if (engine.Game.currentPlayer == engine.Game.Player1)
                panel_p2.Opacity = OPACITY_LOW;
            else
                panel_p1.Opacity = OPACITY_LOW;

            nbTurns.Maximum = engine.Game.Turns;
            nbTurns.Value = nbTurns.Maximum;
            turns.Content = engine.Game.Turns + " tours restants";

            possibleMoves_rects = new List<Rectangle>();
            unitsOnGrid = new List<Image>();

            int size_map = this.engine.Game.Map.Size;
            for (int i = 0; i < size_map; i++)
            {
                RowDefinition gridRow = new RowDefinition();
                grid.RowDefinitions.Add(gridRow);
            }

            for (int i = 0; i < size_map; i++)
            {
                ColumnDefinition gridCol = new ColumnDefinition();
                grid.ColumnDefinitions.Add(gridCol);
            }

            for (int i = 0; i < size_map; i++)
            {
                for (int j = 0; j < size_map; j++)
                {
                    Position position = new Position(i, j);

                    Border rect = new Border();

                    rect.MouseLeftButtonDown += (s, eArgs) =>
                    {
                        EndOfAction(false);
                    };

                    string uri = "";
                    ITile tile = engine.Game.Map.GetTile(position);

                    if (tile is TilePlain)
                        uri = "../../Images/tile_grass.png";
                    else if (tile is TileDesert)
                        uri = "../../Images/tile_desert.png";
                    else if (tile is TileVolcano)
                        uri = "../../Images/tile_volcano.png";
                    else
                        uri = "../../Images/tile_swamp.png";

                    rect.Background = new ImageBrush(new BitmapImage(new Uri(uri, UriKind.Relative)));
                    rect.Background.Opacity = 1;

                    Grid.SetRow(rect, i);
                    Grid.SetColumn(rect, j);
                    grid.Children.Add(rect);
                }
            }

            showUnitsOnGrid();
        }

        public void showUnitsOnGrid()
        {
            foreach (Image img in unitsOnGrid)
                grid.Children.Remove(img);

            int size_map = this.engine.Game.Map.Size;
            for (int i = 0; i < size_map; i++)
            {
                for (int j = 0; j < size_map; j++)
                {
                    bool thereIsAUnit = false;
                    Position position = new Position(i, j);

                    Image image = new Image();
                    if (engine.Game.Player1.GetAllUnitsOnPosition(position).Count > 0)
                    {
                        image.Source = new BitmapImage(new Uri("../../Images/" + url_img_p1 + ".png", UriKind.Relative));
                        thereIsAUnit = true;
                    }

                    if (engine.Game.Player2.GetAllUnitsOnPosition(position).Count > 0)
                    {
                        image.Source = new BitmapImage(new Uri("../../Images/"+url_img_p2+".png", UriKind.Relative));
                        thereIsAUnit = true;
                    }

                    if (thereIsAUnit)
                    {
                        unitsOnGrid.Add(image);
                        image.MouseLeftButtonDown += (s, eArgs) =>
                        {
                            showUnits(position);
                        };

                        Grid.SetRow(image, i);
                        Grid.SetColumn(image, j);
                        grid.Children.Add(image);
                    }
                }
            }
        }

        public void showUnits(Position pos)
        {
            Grid g = grid_units_p1;
            if (engine.Game.currentPlayer == engine.Game.Player2)
                g = grid_units_p2;

            g.Children.Clear();

            List<Unit> units = engine.Game.currentPlayer.GetAllUnitsOnPosition(pos);
            //player1_score.Content = engine.currentPlayer == engine.Game.Player1;
            if (units.Count > 0)
            {
                List<StackPanel> list = new List<StackPanel>();
                for (int i = 0; i < units.Count; i++)
                {
                    RowDefinition gridRow = new RowDefinition();
                    g.RowDefinitions.Add(gridRow);

                    Border rect = new Border();

                    Image img = new Image();
                    if (engine.Game.currentPlayer == engine.Game.Player1)
                        img.Source = new BitmapImage(new Uri("../../Images/"+url_img_p1+".png", UriKind.Relative));
                    else
                        img.Source = new BitmapImage(new Uri("../../Images/" + url_img_p2 + ".png", UriKind.Relative));

                    rect.Child = img;

                    StackPanel info = new StackPanel();
                    info.Orientation = Orientation.Vertical;
                    info.Background = Brushes.White;

                    list.Add(info);

                    Label life = new Label();
                    life.Content = "Life : " + units[i].Life + "\n" + 
                                    "Attack : " + units[i].GetAttackPoints() + "\n" + 
                                    "Defence : " + units[i].GetDefencePoints() + "\n" +
                                    "Moves : " + units[i].Moves;

                    info.Children.Add(life);

                    Grid.SetRow(rect, i);
                    Grid.SetColumn(rect, 0);
                    g.Children.Add(rect);

                    Grid.SetRow(info, i);
                    Grid.SetColumn(info, 1);
                    g.Children.Add(info);

                    if (units.Count > 1)
                    {
                        int index = i;
                        rect.MouseLeftButtonDown += (s, eArgs) =>
                        {
                            unitSelected = units[index];

                            foreach (StackPanel sp in list)
                                sp.Background = Brushes.White;

                            info.Background = Brushes.Green;
                            showPossibleMoves(pos);
                        };

                        info.MouseLeftButtonDown += (s, eArgs) =>
                        {
                            unitSelected = units[index];

                            foreach (StackPanel sp in list)
                                sp.Background = Brushes.White;

                            info.Background = Brushes.Green;
                            showPossibleMoves(pos);
                        };
                    }
                    else
                    {
                        unitSelected = units[0];
                        showPossibleMoves(pos);
                    }

                }
            }
        }

        public void showPossibleMoves(Position posInit)
        {
            clearPossibleMovesOnGrid();
            /*int minX = posInit.X - (int)unitSelected.Moves;
            if(minX<0)
                minX = 0;

            int minY = posInit.Y - (int)unitSelected.Moves;
            if(minY<0)
                minY = 0;

            int maxX = posInit.X + (int)unitSelected.Moves;
            if(maxX > engine.Game.Map.Size)
                maxX = engine.Game.Map.Size;
            
            int maxY = posInit.X + (int)unitSelected.Moves;
            if(maxY > engine.Game.Map.Size)
                maxY = engine.Game.Map.Size;*/
            
            int size_map = this.engine.Game.Map.Size;
            for (int i = 0; i < size_map; i++)
            {
                for (int j = 0; j < size_map; j++)
                {
                    int dist = Math.Abs(i - posInit.X) + Math.Abs(j - posInit.Y);
                    if (dist > 0 && dist <= unitSelected.Moves )
                    {
                        Rectangle rect = new Rectangle();
                        rect.Opacity = 0.6;

                        Player p = engine.Game.Player1;
                        if (engine.Game.currentPlayer == engine.Game.Player1)
                            p = engine.Game.Player2;

                        Position newPosition = new Position(i, j);
                        List<Unit> units = p.GetAllUnitsOnPosition(newPosition);
                        if(units.Count > 0)
                        {
                            rect.Fill = Brushes.Red;

                            rect.MouseLeftButtonDown += (s, eArgs) =>
                            {
                                int moves = Math.Abs(newPosition.X - posInit.X) + Math.Abs(newPosition.Y - posInit.Y);

                                Attack attack = new Attack(new Battle(unitSelected, units, moves));

                                INSA_World.CommandManager cm = INSA_World.CommandManager.Instance;
                                cm.StoreAndExecute(attack);

                                panel_turn.Visibility = Visibility.Visible;
                                panel_title.Content = "BATAILLE";

                                Unit winner = attack.Battle.BattleConsequences.Winner;
                                Unit loser = attack.Battle.BattleConsequences.Loser;

                                panel_message.Content = winner.Race.GetType().Name + " a battu " + loser.Race.GetType().Name + "\n";// + ""
                                panel_message.Content += "Le perdant a subit " + attack.Battle.BattleConsequences.Lost_points + " points de dégats" + "\n";

                                if(loser.Life <= 0)
                                    panel_message.Content += "L'unité est morte !";


                                // Create a Timer with a Normal Priority
                                DispatcherTimer _timerBattle = new DispatcherTimer();

                                // Set the Interval to 2 seconds
                                _timerBattle.Interval = TimeSpan.FromMilliseconds(3000);

                                // Set the callback to just show the time ticking away
                                // NOTE: We are using a control so this has to run on 
                                // the UI thread
                                _timerBattle.Tick += new EventHandler(delegate(object se, EventArgs a)
                                {
                                        panel_turn.Visibility = Visibility.Hidden;
                                        _timerBattle.Stop();
                                });

                                // Start the timer
                                _timerBattle.Start();


                                // On refresh après une action
                                EndOfAction(true);
                            };
                        }
                        else
                        {
                            rect.Fill = Brushes.Green;

                            rect.MouseLeftButtonDown += (s, eArgs) =>
                            {
                                int moves = Math.Abs(newPosition.X - posInit.X) + Math.Abs(newPosition.Y - posInit.Y);

                                Move move = new Move(unitSelected, newPosition, moves);

                                INSA_World.CommandManager cm = INSA_World.CommandManager.Instance;
                                cm.StoreAndExecute(move);

                                // On refresh après une action
                                EndOfAction(true);
                            };
                        }

                        possibleMoves_rects.Add(rect);
                    
                        Grid.SetRow(rect, i);
                        Grid.SetColumn(rect, j);
                        grid.Children.Add(rect);
                    }
                }
            }
        }

        public void clearPossibleMovesOnGrid()
        {
            int size_map = this.engine.Game.Map.Size;
            foreach(Rectangle rect in possibleMoves_rects)
            {
                grid.Children.Remove(rect);
            }

            possibleMoves_rects.Clear();
        }

        private void EndTurn(Object sender, RoutedEventArgs e)
        {
            if(nbTurns.Value > 0)
            {
                EndOfAction(true);
                Player winner = engine.EndTurn();

                panel_p1.Opacity = OPACITY_HIGH;
                panel_p2.Opacity = OPACITY_HIGH;

                if (engine.Game.currentPlayer == engine.Game.Player1)
                    panel_p2.Opacity = OPACITY_LOW;
                else
                    panel_p1.Opacity = OPACITY_LOW;


                if (winner != null)
                {
                    panel_title.Content = "VICTOIRE";
                    panel_message.Content = winner.Name + " a gagné la partie !";
                    panel_turn.Visibility = Visibility.Visible;
                    button_panel.Visibility = Visibility.Visible;

                    victory = true;
                }

                nbTurns.Value -= 0.5;
                turns.Content = engine.Game.Turns + " tours restants";

                player1_score.Content = "Score : " + engine.Game.Player1.Score;
                player2_score.Content = "Score : " + engine.Game.Player2.Score;
                grid_units_p1.Children.Clear();
                grid_units_p2.Children.Clear();
            }

        }

        public void EndOfAction(bool refreshUnits)
        {
            unitSelected = null;
            clearPossibleMovesOnGrid();

            Grid g = grid_units_p1;
            if (engine.Game.currentPlayer == engine.Game.Player2)
                g = grid_units_p2;

            g.Children.Clear();

            if(refreshUnits)
                showUnitsOnGrid();
        }
        
        private void BackToPage1(Object sender, RoutedEventArgs e)
        {
            Switcher.Switch(new Page1(), null);
        }

        private void SaveGame(Object sender, RoutedEventArgs e)
        {
            INSA_World.CommandManager cm = INSA_World.CommandManager.Instance;
            cm.Save(engine.Game);
        }
    }
}
