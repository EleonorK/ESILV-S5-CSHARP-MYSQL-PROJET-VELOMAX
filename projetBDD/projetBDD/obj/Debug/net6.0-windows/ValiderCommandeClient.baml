   M S B A M L   `   `   `  ����D  @projetBDD, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:projetBDD	projetBDD  5   	   %    projetBDD.ValiderCommandeClient   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:projetBDD     5   	   _ [MaterialDesignThemes.Wpf, Version=4.5.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	      MaterialDesignBody#���   5	   	   $��Regular"�5
   	   $��13(�5   	   &   System.Windows.Media.TextOptions    TextFormattingMode$  Ideal=�5   	      TextRenderingMode$
 Auto=�5   	     MaterialDesignPaper#���  5   	     MaterialDesignFont#���  5   	    � Title$ ValiderCommandeClient��5   	   $	��700��6'   $
��1000��64    � AllowsTransparency$
 True��6A    � WindowStyle$
 None=�6[   .��5      � .+�5   
   �� $��VALIDER LA COMMANDE��6   $��30(�6.   $��Javanese Text)�6<   $��300,0,300,620q�6W   �� 5   
   -   5        $��bt_exit��5       / +MaterialDesignFloatingActionMiniLightButton#��[ 5       � ToolTip$ Fermer la fenêtre��5      $��960,-650,0,0q�6V   ��6)   Z� ��6?   Z� .��5      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ CloseCircle=�5      $��21��6$   $��30��60   5      �� 5   
   -   5        $��	bt_retour��5       . *MaterialDesignFloatingActionMiniDarkButton#��[ 5      $ Page précédente��5      $
��Auto��6@   $
��Auto��6N   ���	#DD000000���	#FFD5D4D9���	#DD000000 � Cursor$
 Hand��6�   $��10,10,950,649q�6�   .��5        $ 	ArrowBack=�5      5      �� 5   
   -   5        $��	cb_client��5       " MaterialDesignOutlinedComboBox#��[ 5    	   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Produit��5!      $��20,120,700,0q�67   $��92��6M   $	��270��6Y   $��Javanese Text)�6e   $��20(�6�   $	��Top=�6�   .@�5"      �� $��INDIVUDU��5#      �� 5$      $��BOUTIQUE��5%      5&      �� 5'   
   -   5        	 ��Name$	 bt_verifProduit��5'       " MaterialDesignRaisedDarkButton#��[ 5(      +  %MaterialDesignThemes.Wpf.ButtonAssist
   CornerRadius$
 25��5)      $7 1MaterialDesignRaisedDarkButton with Round Corners��5*      $��Javanese Text)�5+   �   $��324,142,526,508q�6�   $��50��6�   {�6   �� *DataContext.ControlsEnabled+ �� RelativeSource �� *FindAncestor+ �� AncestorType" �.��5,      �� $��	confirmer��5-      5.      �� 5/   
   -   5         ��Name$ tx_nom��5/      $��92��6"    ! MaterialDesignOutlinedTextBox#��[ 50       �� TextWrapping$
 Wrap=�51      " �� VerticalScrollBarVisibility$
 Auto=�53      $ Nom du Client/Boutique��54      $��Javanese Text)�6E   $��20(�6`   $��503,114,227,494q�6n   .  (MaterialDesignThemes.Wpf.TextFieldAssist!   CharacterCounterVisibility 52      �� *	IsChecked+   BooleanToVisibilityConverter �� 	Converter# [  �� ElementName$4 .MaterialDesignOutlinedTextBoxTextCountComboBox��54   n   �� 55   
   -   5        $	 bt_RechercheNom��55      #��[ 56      $ 
Rechercher��57      $��811,140,149,520q�6"   ���	#FFE5E4E4���	#FFE5E4E4���	#DD000000 J� RenderTransformOrigin$ 
0.715,0.91&�6�   $
��Auto��6�   $
��Auto��6�   .��58        $ Magnify=�59      $��30��6    $��22��6,   5:      �� 5;   
   -   5        $	 bt_verif��5;      #��[ 5<      $
 25��5=      $7 1MaterialDesignRaisedDarkButton with Round Corners��5>      $��Javanese Text)�5?   �   $��819,622,31,28q�6�   $��50��6�   {�6   �� *DataContext.ControlsEnabled+ �� *FindAncestor+" �.��5@      �� $��	confirmer��5A      5B      �� 5C   
   -   5        $��lb_prix��5C      $��0,291,0,322q�6   $��30(�64   $��Javanese Text)�6B   5D      5E      