   M S B A M L   `   `   `  ����D  @projetBDD, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:projetBDD	projetBDD  5   	       projetBDD.CommandeGerant   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:projetBDD     5   	   _ [MaterialDesignThemes.Wpf, Version=4.5.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	      MaterialDesignBody#���   5	   	   $��Regular"�5
   	   $��13(�5   	   &   System.Windows.Media.TextOptions    TextFormattingMode$  Ideal=�5   	      TextRenderingMode$
 Auto=�5   	     MaterialDesignPaper#���  5   	     MaterialDesignFont#���  5   	    � Title$ CommandeGerant��5   	   $	��700��6    $
��1000��6-    � AllowsTransparency$
 True��6:    � WindowStyle$
 None=�6T   .��5      �  J� RenderTransformOrigin$ 0.494,0.512&�6   ���	#FFE5E4E4.+�5   
   �� $��PASSER COMMANDE��6   $��30(�6*   $��Javanese Text)�68   $��300,0,300,620q�6S   �� 5   
   -   5        $��bt_exit��5       / +MaterialDesignFloatingActionMiniLightButton#��[ 5       � ToolTip$ Fermer la fenêtre��5      $��960,-650,0,0q�6V   ��6)   Z� ��6?   Z� .��5      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ CloseCircle=�5      $��21��6$   $��30��60   5      �� 5   
   -   5        $��	bt_retour��5       . *MaterialDesignFloatingActionMiniDarkButton#��[ 5      $ Page précédente��5      $
��Auto��6@   $
��Auto��6N   ���	#DD000000���	#FFD5D4D9���	#DD000000 � Cursor$
 Hand��6�   $��10,10,950,649q�6�   .��5        $ 	ArrowBack=�5      5      �� 5    
   -   5        	 ��Name$	 tbnom_piece��5!      .  (MaterialDesignThemes.Wpf.TextFieldAssist
   HasClearButton$

 True��5"      )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Nom de la pièce��5#      $��33,63,712,585q�5$      ��6$   �� *Name+ �� UpdateSourceTrigger$ PropertyChanged=��� 5%   
   -   5        #��[ 5&      $ 
Rechercher��5'      $��317,75,643,585q�6"   ���	#FFE5E4E4���	#FFE5E4E4���	#DD000000$ 
0.715,0.91&�6�   $
��Auto��6�   $
��Auto��6�   .��5(        $ Magnify=�5)      $��30��6    $��22��6,   5*      &   System.Windows.Controls.DataGrid  5-   
   -   5          Name$ dgPiece��5-      $
��Left=�6%   $	��386��6@   $��
10,136,0,0q�6M   $	��Top=�6a   $	��734��6y   ���	#FFD7CECE$��2��6�   �� 5.   
   -   5        $��lbPanier��5.      $
��Left=�6#   $	��386��6>   $��790,136,0,0q�6K   $	��Top=�6`   $	��150��6x   ���	#FFEBFF02���	#DD000000���	#FFD7CECE6�   �� 5/   
   -   5        $��Valider la commande��5/      $
��Left=�6/   $��790,598,0,0q�6J   $	��Top=�6_   $	��150��6w   $ -0.343,0.297&�6�   $��44��6�   $��12(�6�   ���	#FFD7CECE
����������	#DD000000$
��Bold"�6  �� 50   
   -   5        $��tbPrixTotal��50      $
��Left=�6%   $��35��6@   $��790,544,0,0q�6L    �� TextWrapping$
 Wrap=�6a   $�� ��6u   $	��Top=�6}   $	��150��6�   $ 0.485,-0.409&�6�   ${�False��6�   $��14(�6�   �� 51   
   $��Prix Total TTC :��6   $
��Left=�6+   $��635,554,0,0q�6F   $	��Top=�6[   $	��109��6s   $
��Bold"�6   $��14(�6�   �� 52   
   -	   5        $��	Supprimer��52      #��[ 53      $ 	Supprimer��54      $��844,461,116,199q�6!   $ 
0.715,0.91&�6R   $
��Auto��6u   $
��Auto��6�   ���	#DD000000���	#FFD7CECE��6�   Z�  J� OpacityMask 55      �� 56       �� EndPoint$ 0.5,1&�6&    �� 
StartPoint$ 0.5,0&�67   .��57      �  � Color$ Black��6#    � Offset$ 0Q�61   � 58      $ 	#FFFFF9F9��6#   $ 1Q�65   59      .��5;        $ TrashCanOutline=�5<      $��30��6(   $��22��64   5=      �� 5>   
   $��
Mon panier��6   $
��Left=�6%   $��
822,87,0,0q�6@   $	��Top=�6T   $��14(�6l   $
��Bold"�6z   $ -0.11,0.348&�6�   $��84��6�   5?      5@      