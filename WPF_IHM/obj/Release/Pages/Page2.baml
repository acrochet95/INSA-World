   M S B A M L   `   `   `  ����   WPF_IHM    WPF_IHM.Page2   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008       N� Title$  Page2�� N� 
Background ��  �� ImageSource$ ../Images/background.png��.��� .+���  �� Orientation$ Vertical=�$��0,20,0,0q�.+��� -   $��demoMap��$ 
Horizontal=�$��90��$	��800��.+��� $	��130��$��90������ $ ../Images/demo_map.png���� $	��670��$��90�����	#80FF0000
�������$��16(�$
��Wrap=�Carte Démonstration�� 20Affrontez votre adversaire sur une petite carte.�� IGCaractéristiques : Carte 6x6 cases, 4 unités par joueur, 5 tours max.�� -   $��smallMap��$ 
Horizontal=�$��90��$	��800��.+��� $	��130��$��90������ $ ../Images/small_map.png���� $	��670��$��90�����	#80FF0000
�������$��16(�$
��Wrap=�Carte Moyenne�� =;Affrontez votre adversaire sur une carte de taille moyenne.�� LJCaractéristiques : Carte 10x10 cases, 6 unités par joueur, 20 tours max.�� -   $��standardMap��$ 
Horizontal=�$��90��$	��800��.+��� $	��130��$��90������ $  ../Images/standard_map.png���� $	��670��$��90�����	#80FF0000
�������$��16(�$
��Wrap=�Carte Standard�� 42Affrontez votre adversaire sur une carte standard.�� LJCaractéristiques : Carte 14x14 cases, 8 unités par joueur, 30 tours max.�� $ 
Horizontal=�$
��Auto��$
��Auto��$��Center=�$��0,30,0,0q�.+��� $ Vertical=�$	��240��$	��350�����	#AAFFFFFF$��	0,0,100,0q�.+��� $��PLAYER 1��$��Center=��� $ 
Horizontal=�$
��Auto��$
��Auto��$
��Left=�$��0,20,0,0q�.+��� $��Nom :��$��16(�$��	10,0,20,0q��� -   $��name_player1��$	��250��$�� ���� $ 
Horizontal=�$
��Auto��$
��Auto��$
��Left=�$��0,20,0,0q�.+��� $��Race :��$��16(�$��	10,0,20,0q��� $ Vertical=�$
��Auto��$
��Auto��.+�	� -   $��cyclop1��$��5q� 	� 	GroupName$
 Race��$��Cyclope��	� -   $��centaur1��$��5q�$
 Race��$��Centaure��	� -   $��	cerberus1��$��5q�$
 Race��$��Cerbère���� $ Vertical=�$	��240��$	��350�����	#AAFFFFFF.+��� $��PLAYER 2��$��Center=��� $ 
Horizontal=�$
��Auto��$
��Auto��$
��Left=�$��0,20,0,0q�.+��� $��Nom :��$��16(�$��	10,0,20,0q��� -   $��name_player2��$	��250��$�� ���� $ 
Horizontal=�$
��Auto��$
��Auto��$
��Left=�$��0,20,0,0q�.+��� $��Race :��$��16(�$��	10,0,20,0q��� $ Vertical=�$
��Auto��$
��Auto��.+�	� -	   $��cyclop2��$��5q�$ Race2��$��Cyclope��	� -
   $��centaur2��$��5q�$ Race2��$��Centaure��	� -   $��	cerberus2��$��5q�$ Race2��$��Cerbère���� -   $��Commencer la partie !��$��-200,600,0,0q�$��50��$	��300���� -   $��Annuler��$��400,600,0,0q�$��50��$	��150��