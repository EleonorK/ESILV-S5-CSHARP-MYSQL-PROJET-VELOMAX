   M S B A M L   `   `   `  ����D  @projetBDD, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:projetBDD	projetBDD  5   	       projetBDD.CommandeClient   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:projetBDD     5   	   _ [MaterialDesignThemes.Wpf, Version=4.5.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	      MaterialDesignBody#���   5	   	   $��Regular"�5
   	   $��13(�5   	   &   System.Windows.Media.TextOptions    TextFormattingMode$  Ideal=�5   	      TextRenderingMode$
 Auto=�5   	     MaterialDesignPaper#���  5   	     MaterialDesignFont#���  5   	    � Title$ CommandeClient��5   	   $	��700��6    $
��1000��6-    � AllowsTransparency$
 True��6:    � WindowStyle$
 None=�6T   .��5      � ���	#FFCCC5C5.+�5   
   �� $��COMMANDE CLIENT��6   $��30(�6*   $��Javanese Text)�68   $��376,0,224,620q�6S   �� 5   
   -   5        $��bt_exit��5       / +MaterialDesignFloatingActionMiniLightButton#��[ 5       � ToolTip$ Fermer la fenêtre��5      $��960,-650,0,0q�6V   ��6)   Z� ��6?   Z� .��5      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ CloseCircle=�5      $��21��6$   $��30��60   5      �� 5   
   -   5        $��	bt_retour��5       . *MaterialDesignFloatingActionMiniDarkButton#��[ 5      $ Page précédente��5      $
��Auto��6@   $
��Auto��6N   ���	#DD000000���	#FFD5D4D9���	#DD000000 � Cursor$
 Hand��6�   $��10,10,950,649q�6�   .��5        $ 	ArrowBack=�5      5      &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ dgVelo��5      $
��Left=�6$   $	��208��6?   $��
10,122,0,0q�6L   $	��Top=�6`   $	��606��6x   ���	#FFD7CECE6�   �� 5    
   -   5        	 ��Name$	 lbPanier��5       $
��Left=�6%   $	��464��6@   $��
805,84,0,0q�6M   $	��Top=�6a   $	��169��6y   ���	#FFEBFF02���	#DD000000���	#FFD7CECE6�   �� 5!   
   $��
Mon panier��6   $
��Left=�6%   $��
848,38,0,0q�6@   $	��Top=�6T   $��14(�6l   $
��Bold"�6z   
 J� RenderTransformOrigin$
 -0.11,0.348&�6�   $��84��6�   �� 5"   
   -   5         ��Name$ 
tbnom_velo��5#      .  (MaterialDesignThemes.Wpf.TextFieldAssist   HasClearButton$
 True��5$      )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Nom du vélo��5%      $��26,56,762,602q�5&      ��6$   �� *Name+ �� UpdateSourceTrigger$ PropertyChanged=��� 5'   
   -   5        #��[ 5(      $ 
Rechercher��5)      $��286,58,674,602q�6"   ���	#FFE5E4E4���	#FFE5E4E4���	#DD000000$
 
0.715,0.91&�6�   $
��Auto��6�   $
��Auto��6�   .��5*        $ Magnify=�5+      $��30��6    $��22��6,   5,      �� 5-   
   $��Prix Total TTC :��6   $
��Left=�6+   $��678,575,0,0q�6F   $	��Top=�6[   $	��109��6s   $
��Bold"�6   $��14(�6�   �� 5.   
   -   5        $ tbPrixTotal��5.      $
��Left=�6'   $��35��6B   $��805,559,0,0q�6N    �� TextWrapping$
 Wrap=�6c   $�� ��6w   $	��Top=�6   $	��169��6�   $
 0.485,-0.409&�6�   ${�False��6�   $��14(�6�   �� 5/   
   -   5        $��Valider la commande��5/      $
��Left=�6/   $��805,613,0,0q�6J   $	��Top=�6_   $	��169��6w   $
 -0.343,0.297&�6�   $��44��6�   $��12(�6�   ���	#FFD7CECE���	#FFD7CECE���	#DD000000$
��Bold"�6  �� 50   
   -	   5        #��[ 51      $ 	Supprimer��52      $��870,496,90,164q�6!   ���	#FFD7CECE���	#FFD7CECE���	#DD000000$
 
0.715,0.91&�6�   $
��Auto��6�   $
��Auto��6�   .��53        $ TrashCanOutline=�54      $��30��6(   $��22��64   55      �� 56   
   -
   5        $ tbnom_piece��57      $
 True��58      $ Nom de la pièce��59      $��26,344,761.6,283.4q�5:      ��6)   �� *Name+$ PropertyChanged=�  5;   
   -   5        $ dgPiece��5;      $
��Left=�6%   $	��208��6@   $��
10,432,0,0q�6M   $	��Top=�6a   $	��606��6y   ���	#FFD7CECE6�   �� 5<   
   -   5        #��[ 5=      $ 
Rechercher��5>      $��288,390,671,270q�6"   ���	#FFE5E4E4���	#FFE5E4E4���	#DD000000$
 
0.715,0.91&�6�   $
��Auto��6�   $
��Auto��6�   .��5?        $ Magnify=�5@      $��30��6    $��22��6,   5A      5B      5C      