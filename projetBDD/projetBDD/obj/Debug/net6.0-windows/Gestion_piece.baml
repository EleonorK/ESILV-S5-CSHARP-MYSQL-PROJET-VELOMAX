   M S B A M L   `   `   `  ����D  @projetBDD, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:projetBDD	projetBDD  5   	       projetBDD.Gestion_piece   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:projetBDD     5   	   _ [MaterialDesignThemes.Wpf, Version=4.5.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	      MaterialDesignBody#���   5	   	   $��Regular"�5
   	   $��13(�5   	   &   System.Windows.Media.TextOptions    TextFormattingMode$  Ideal=�5   	      TextRenderingMode$
 Auto=�5   	     MaterialDesignPaper#���  5   	     MaterialDesignFont#���  5   	    � Title$ Gestion_piece��5   	   $	��700��6   $
��1000��6,    � AllowsTransparency$
 True��69    � WindowStyle$
 None=�6S   .��5      � .+�5   
   �� $��GESTION DES PIECES��6   $��30(�6-   $��Javanese Text)�6;   $��300,0,300,620q�6V   �� 5   
   -   5        $��bt_exit��5       / +MaterialDesignFloatingActionMiniLightButton#��[ 5       � ToolTip$ Fermer la fenêtre��5      $��960,-650,0,0q�6V   ��6)   Z� ��6?   Z� .��5      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ CloseCircle=�5      $��21��6$   $��30��60   5      �� 5   
   -   5        $��	bt_retour��5       . *MaterialDesignFloatingActionMiniDarkButton#��[ 5      $ Page précédente��5      $
��Auto��6@   $
��Auto��6N   ���	#DD000000���	#FFD5D4D9���	#DD000000 � Cursor$
 Hand��6�   $��10,10,950,649q�6�   .��5        $ 	ArrowBack=�5      5      �� 5   
   -   5         ��Name$ 
tbid_siret��5       .  (MaterialDesignThemes.Wpf.TextFieldAssist	   HasClearButton$
	 True��5!      )  #MaterialDesignThemes.Wpf.HintAssist
   Hint$
 Siret��5"      $��329,104,562,552q�5#      ��6&   �� *Name+ �� UpdateSourceTrigger$ PropertyChanged=��� 5$   
   -   5        $��
Rechercher��5$      $
��Left=�6&   $��516,114,0,0q�6A   $	��Top=�6V   $	��107��6n    J� RenderTransformOrigin$ 0.095,0.987&�6z   $��27��6�   6�   &   System.Windows.Controls.DataGrid  5%   
   -   5        $��dgPiece��5%      $
��Left=�6#   $	��339��6>   $��
31,161,0,0q�6K   $	��Top=�6_   $	��943��6w   ���	#FFD7CECE6�   �� 5&   
   $��Ligne selectionnée :��6   $
��Left=�6/   $��
15,505,0,0q�6J   $	��Top=�6^   $	��154��6v   $��15(�6�   $
��Bold"�6�   $ 0.356,2.064&�6�   �� 5'   
   -   5        $ lsdescription��5'      $
 description��6*   $
��Left=�6W   $��23��6r   $��533,538,0,0q�6~    �� TextWrapping$
 Wrap=�6�   $	��Top=�6�   $��77��6�   $ 0.457,1.183&�6�   �� 5(   
   -   5        $ lsprix_piece��5(      $

 prix��6)   $
��Left=�6O   $��23��6j   $��395,538,0,0q�6v   $
 Wrap=�6�   $	��Top=�6�   $��77��6�   $ 0.457,1.183&�6�   �� 5)   
   -   5        $ lsnum_pieceFournisseur��5)      $
 n°pièce fournisseur��63   $��Right=�6h   $��23��6�   $��0,538,652.6,0q�6�   $
 Wrap=�6�   $	��Top=�6�   $	��107��6�   $ 0.457,1.183&�6�   ${�False��6  �� 5*   
   -	   5        $ 
lsid_siret��5*      $
 siret��6'   $
��Left=�6N   $��23��6i   $��109,538,0,0q�6u   $
 Wrap=�6�   $	��Top=�6�   $��77��6�   $ 0.457,1.183&�6�   ${�False��6�   �� 5+   
   -
   5        $��Modifier��5+      $
��Left=�6$   $��312,615,0,0q�6?   $	��Top=�6T   $	��120��6l   6x   �� 5,   
   -   5        $��	Supprimer��5,      $
��Left=�6%   $��533,615,0,0q�6@   $	��Top=�6U   $	��124��6m   $ 0.124,0.984&�6y   6�   �� 5-   
   -   5        $ lsstock_piece��5-      $
 stock��6*   $
��Left=�6Q   $��23��6l   $��852,538,0,0q�6x   $
 Wrap=�6�   $	��Top=�6�   $��77��6�   $ 0.457,1.183&�6�   �� 5.   
   -   5        $ lsdelai��5.      $
 délai��6$   $
��Left=�6K   $��23��6f   $��684,538,0,0q�6r   $
 Wrap=�6�   $	��Top=�6�   $��77��6�   $ 0.457,1.183&�6�   �� 5/   
   -   5        $ 
lsid_piece��5/      $
 id��6'   $
��Left=�6K   $��28��6f   $��	6,533,0,0q�6r   $
 Wrap=�6�   $	��Top=�6�   $��77��6�   $ 0.457,1.183&�6�   ${�False��6�   �� 50   
   -   5        $ tbnom_piece��51      $
	 True��52      $
 Nom de la pièce��53      $��126,104,741,552q�54      ��6&   �� *Name+$ PropertyChanged=�56      57      