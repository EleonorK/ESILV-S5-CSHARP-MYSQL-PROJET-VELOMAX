   M S B A M L   `   `   `  ����D  @projetBDD, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:projetBDD	projetBDD  5   	        projetBDD.creation_produit   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:projetBDD     5   	   _ [MaterialDesignThemes.Wpf, Version=4.5.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	      MaterialDesignBody#���   5	   	   $��Regular"�5
   	   $��13(�5   	   &   System.Windows.Media.TextOptions    TextFormattingMode$  Ideal=�5   	      TextRenderingMode$
 Auto=�5   	     MaterialDesignPaper#���  5   	     MaterialDesignFont#���  5   	    � Title$ creation_produit��5   	   $	��700��6"   $
��1000��6/    � AllowsTransparency$
 True��6<    � WindowStyle$
 None=�6V   .��5      � .+�5   
   � -   5        $��	grid_velo��5      $��313,83,313,0q�6    $y�Hidden=�66   .+�5      �� -   5        $��
tx_nomVelo��5      $��92��6(    ! MaterialDesignOutlinedTextBox#��[ 5       �� TextWrapping$
 Wrap=�5      " �� VerticalScrollBarVisibility$
 Auto=�5      )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ nom du velo��5      $��Javanese Text)�6:   $��20(�6U   $��54,0,54,440q�6c   .  (MaterialDesignThemes.Wpf.TextFieldAssist!   CharacterCounterVisibility 5      �� *	IsChecked+   BooleanToVisibilityConverter	 �� 	Converter#	 [ 
 �� ElementName$4
 .MaterialDesignOutlinedTextBoxTextCountComboBox��5   c   �� 5      -   5        $��cb_grandeur��5      $��92��6*    " MaterialDesignOutlinedComboBox#��[ 5   	   $ Grandeur��5      $��Javanese Text)�68   $��20(�6S   $	��Top=�6a   $��54,289,54,0q�6y   .@�5      �� $��Adulte��5      �� 5      $��Homme��5      �� 5       $��Femme��5!      �� 5"      $��Jeune��5#      �� 5$      $��Garçon��5%      �� 5&      $��Fille��5'      5(      �� 5)      -   5         ��Name$ tx_ligneVelo��5)      $��92��6-   #��[ 5*      $ 
Ligne velo��5+      $��Javanese Text)�6=   $��20(�6X   $��54,0,54,190q�6f    � Cursor$ Arrow��6{   .@�5,      �� $	��VTT��5-      �� 5.      $��Vélo de course��5/      �� 50      $��	Classique��51      �� 52      $	��BMX��53      54      55      � 56   
   -   5        $��
grid_piece��56      $��313,98,313,0q�6!   .+�57      �� -   5         ��Name$ 
tx_idSiret��57      $��92��6N   #��[ 58      $
 Wrap=�59      $
 Auto=�5;      $ N°fournisseur��5<      $��Javanese Text)�6@   $��20(�6[   $��54,20,54,490q�6i    5:      �� *	IsChecked+#	 [ $4
 .MaterialDesignOutlinedTextBoxTextCountComboBox��5<   i   �� 5=      -   5        $��cb_numPieceFournisseur��5=      $��92��65   #��[ 5>      $ N°piece fournisseur��5?      $��20(�6F   $��Javanese Text)�6T   $��72��5@       �� 
IsEditable$
 True��5A      $��54,139,54,0q�5B   K   $	��Top=�6`   ��6   �� *#!LongListToTestComboVirtualization+��5C      �� 5D      .R�5E      $� 5F      5H      �� 5I      -   5        $ tx_desPiece��5I      $	��150��6+   #��[ 5J      $
 Wrap=�5K       �� 	MaxLength$	 255��5L      $
 Auto=�5N      $ description de la piece��5O      $��Javanese Text)�6J   $��20(�6e   $��54,403,54,49q�6s    5M      �� *	IsChecked+#	 [ $4
 .MaterialDesignOutlinedTextBoxTextCountComboBox��5O   s   �� 5P      -	   5        $ tx_delaiPiece��5P      $��92��6-   #��[ 5Q      $
 Wrap=�5R      $
 Auto=�5T      $ delais de la piece��5U      $��Javanese Text)�6E   $��20(�6`   $��54,272,54,238q�6n   $ Arrow��6�    5S      �� *	IsChecked+#	 [ $4
 .MaterialDesignOutlinedTextBoxTextCountComboBox��5U   �   5W      � 5X   
   -
   5         �Name$ 
grid_choix��5X      $��10,10,0,444q�6#   $y�Hidden=�68   .+�5Y      �� -   5        $��bt_exit��5Y       / +MaterialDesignFloatingActionMiniLightButton#��[ 5Z       � ToolTip$ Fermer la fenêtre��5[      $��950,-206,0,0q�6V   ��6)   Z� ��6?   Z� .��5\      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ CloseCircle=�5]      $��21��6$   $��30��60   5^      �� 5_      -   5        $��	bt_retour��5_       . *MaterialDesignFloatingActionMiniDarkButton#��[ 5`      $ Page précédente��5a      $
��Auto��6@   $
��Auto��6N   ���	#DD000000���	#FFD5D4D9���	#DD000000$
 Hand��6�   $��10,10,940,200q�6�   .��5b        $ 	ArrowBack=�5c      5d      �� 5e      $#��CREATION D'UN NOUVEAU PRODUIT��6   $��30(�6<   $��Javanese Text)�6J   $��196,0,65,159q�6e   �� 5f      -   5        $��
cb_produit��5f      #��[ 5g   	   $ Produit��5h      $��20,120,700,0q�67   $��92��6M   $	��270��6Y   $��Javanese Text)�6e   $��20(�6�   $	��Top=�6�   .@�5i      �� $
��VELO��5j      �� 5k      $��PIECE��5l      5m      �� 5n      -   5         ��Name$ bt_verifProduit��5n       " MaterialDesignRaisedDarkButton#��[ 5o      +  %MaterialDesignThemes.Wpf.ButtonAssist   CornerRadius$ 25��5p      $7 1MaterialDesignRaisedDarkButton with Round Corners��5q      $��Javanese Text)�5r   �   $��350,65,500,0q�6�   $��50��6�   {�6   �� *DataContext.ControlsEnabled+ �� RelativeSource �� *FindAncestor+ �� AncestorType" �.��5s      �� $��	confirmer��5t      5u      5w      � 5x   
   -   5        $ grid_original��5x      .+�5y      �� -   5        $ tx_numProduit��5y      $��92��6-   #��[ 5z      $
 Wrap=�5{      $
 Auto=�5}      $ 
Réference��5~      $��Javanese Text)�68   $��20(�6S   $��700,0,30,130q�6a    5|      �� *	IsChecked+#	 [ $4
 .MaterialDesignOutlinedTextBoxTextCountComboBox��5~   a   �� 5      -   5        $ tx_prix��5      $��92��6'   #��[ 5�      $	��Top=�5�         HasClearButton$
 True��5�         
SuffixText$ € eur��5�      $��30(�6?   $��Javanese Text)�6M   $��30,240,700,0q�6h   $ Arrow��6~   .��6�    5�      �� 5�      $ Password��5�         
HelperText$ Helper text��5�       �� Orientation$ 
Horizontal=�5�      .+�5�      �� $��  prix du produit��5�      $��20(�62   $	��189��6@   5�      .��5�   2   5�      (  "System.Windows.Controls.DatePicker  5�      -   5          Name$ tx_dateDebut��5�      $��92��6#   $ Debut de production��5�      $��20(�6B   $��Javanese Text)�6P   $��30,372,700,0q�6k   $	��Top=�6�    $	  MaterialDesignOutlinedDatePicker#��[	 5�        5�      -   5        $ 
tx_dateFin��5�      $��89��6!   $ Debut de discontinuation��5�      $��20(�6G   $��Javanese Text)�6U   $��30,502,700,0q�6p   $	��Top=�6�   #��[	 5�      �� 5�      -   5        $ cb_stock��5�      $��92��6)   #��[ 5�      $ stock��5�      $��20(�64   $��Javanese Text)�6B   $��72��5�      $ False��5�      $��700,120,30,0q�5�   G   $	��Top=�6]   ��6   �� *#!LongListToTestComboVirtualization+��5�      �� 5�      .R�5�      $� 5�      5�      �� 5�      -   5        #��[ 5�      $ 25��5�      $7 1MaterialDesignRaisedDarkButton with Round Corners��5�      $��50��5�   �   $��770,610,30,19q�6�   $
 Hand��6�   {�6   �� *DataContext.ControlsEnabled+ �� *FindAncestor+" �.��5�      �� $��VERIF��5�      5�      �� 5�      -   5        $ tx_nomPiece��5�      $��92��6+   #��[ 5�      $
 Wrap=�5�      $
 Auto=�5�      $ Nom de la piece��5�      $��Javanese Text)�6B   $��20(�6]   $��700,369,30,239q�6k   $ Arrow��6�    5�      �� *	IsChecked+#	 [ $4
 .MaterialDesignOutlinedTextBoxTextCountComboBox��5�   �   5�      5�      5�      