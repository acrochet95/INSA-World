   M S B A M L   `   `   `  ����   WPF_IHM    WPF_IHM.Pages.Game   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008       N� Title$
  Game�� N� 
Background ��  �� ImageSource$ ../Images/background.png��.���  � ColumnDefinitions �� $��* ��� $��2* ��� $��* � � RowDefinitions �� $��3* ��� $��* �.+��� -   $��panel_p1��$��0��$��1��$��0��.+���  �� Orientation$ Vertical=�$	��200������  �� EndPoint$	 0,1&� �� 
StartPoint$	 0,0&�.���  � Color$ White��	 � Offset$	 0Q�� $ 	#00FFFFFF��$	 1Q�.+��� -   $��player1_name��$��PLAYER 1��$��25(�$��0,15,0,0q�$��Center=��� -   $��player1_race��$��Race :��$��20(�$��	10,15,0,0q�$
��Left=��� -   $��player1_score��$��	Score : 0��$��20(�$��	10,15,0,0q�$
��Left=�� -   $��grid_units_p1��$��
10,15,10,0q� �� $��* ��� $��3* �� -   $
��grid��$��0��$��1��
��������� -   $��
panel_turn��$��0��$��1��$��Center=�$	��270��$	��500��$��Center=����� $ ../Images/panel.png��.+��� -   $��panel_title��$��NOUVEAU TOUR��$��30(�$��Center=�$��10,50,10,10q��� -	   $��panel_message��$!��C'est à Antoine de jouer !��$��20(�$��Center=�$��
10,0,10,10q��� -
   $��button_panel��$��Retour à l'accueil��$	��200��$��30���� -   $��panel_p2��$��0��$��2��$ Vertical=�.+��� $ Vertical=�$	��200������ $	 0,1&�$	 0,0&�.��� $ White��$	 0Q�� $ 	#00FFFFFF��$	 1Q�.+��� -   $��player2_name��$��PLAYER 2��$��25(�$��0,15,0,0q�$��Center=��� -   $��player2_race��$��Race :��$��20(�$��	10,15,0,0q�$
��Left=��� -   $��player2_score��$��	Score : 0��$��20(�$��	10,15,0,0q�$
��Left=�� -   $��grid_units_p2��$��
10,15,10,0q� �� $��* ��� $��3* �� $��1��$��1��$��0,20,0,0q�$��Stretch=� �� $
��Auto ��� $
��Auto ��� $��* � �� $��* ��� $��3* �.+��� $ 
Horizontal=�$��0��$��0��.+�� -   $��nbTurns��
 � Minimum$
 0Q� � Maximum$	 100Q�$	��200��$��30���� -   $��turns��$��10 tours restants��$��16(�$��30��
�������$��	20,0,20,0q��� -   $��Fin du tour��$��0,0,0,0q�$��30��$	��120��$��2��$��0��$��Right=��� $ 
Horizontal=�$��Center=�$��3��$��1��$��Center=�.+��� -   $��Enregistrer partie��$��0,0,0,0q�$��30��$	��200���� -   $��Quitter Partie��$��20,0,0,0q�$��30��$	��200��