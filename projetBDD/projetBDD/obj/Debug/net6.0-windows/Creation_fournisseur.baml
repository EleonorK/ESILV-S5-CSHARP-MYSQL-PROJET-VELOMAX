   M S B A M L   `   `   `  ����D  @projetBDD, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:projetBDD	projetBDD  5   	   $    projetBDD.Creation_fournisseur   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:projetBDD     5   	   _ [MaterialDesignThemes.Wpf, Version=4.5.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	      MaterialDesignBody#���   5	   	   $��Regular"�5
   	   $��13(�5   	   &   System.Windows.Media.TextOptions    TextFormattingMode$  Ideal=�5   	      TextRenderingMode$
 Auto=�5   	     MaterialDesignPaper#���  5   	     MaterialDesignFont#���  5   	    � Title$ Creation_fournisseur��5   	   $	��700��6&   $
��1000��63    � AllowsTransparency$
 True��6@    � WindowStyle$
 None=�6Z   .��5      � .+�5   
   �� $��CREATION D'UN FOURNISSEUR��6   $��30(�64   $��Javanese Text)�6B   $��261,0,261,620q�6]   �� 5   
   -   5        $��bt_exit��5       / +MaterialDesignFloatingActionMiniLightButton#��[ 5       � ToolTip$ Fermer la fenêtre��5      $��960,-650,0,0q�6V   ��6)   Z� ��6?   Z� .��5      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ CloseCircle=�5      $��21��6$   $��30��60   5      �� 5   
   -   5        $��	bt_retour��5       . *MaterialDesignFloatingActionMiniDarkButton#��[ 5      $ Page précédente��5      $
��Auto��6@   $
��Auto��6N   ���	#DD000000���	#FFD5D4D9���	#DD000000 � Cursor$
 Hand��6�   $��10,10,950,649q�6�   .��5        $ 	ArrowBack=�5      5      �� 5   
   -   5         ��Name$ tx_nonEntreprise��5      $��92��6,    ! MaterialDesignOutlinedTextBox#��[ 5       	 �� TextWrapping$
	 Wrap=�5!      "
 �� VerticalScrollBarVisibility$

 Auto=�5#      )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Nom de la société��5$      $��Javanese Text)�6@   $��20(�6[   $��30,129,475,479q�6i   .  (MaterialDesignThemes.Wpf.TextFieldAssist!   CharacterCounterVisibility 5"      �� *	IsChecked+   BooleanToVisibilityConverter �� 	Converter# [  �� ElementName$4 .MaterialDesignOutlinedTextBoxTextCountComboBox��5$   i   �� 5%   
   $��0,218,0,432q�6   $���-----------------ADRESSE-------------------------------------------------------------------------------------------------------��6%   $��Javanese Text)�5&      $��20(�63   6D   �� 5'      -   5        $ tx_rue��5'      $��85��6*   #��[ 5(      $
	 Wrap=�5)      $

 Auto=�5+      $	 Rue��5,      $��Javanese Text)�6:   $��20(�6U   $��30,263,293,352q�6c    5*      �� *	IsChecked+# [ $4 .MaterialDesignOutlinedTextBoxTextCountComboBox��5,   c   �� 5-      -   5        $ tx_ville��5-      $��85��6,   #��[ 5.      $
	 Wrap=�5/      $

 Auto=�51      $ Ville��52      $��Javanese Text)�6<   $��20(�6W   $��30,365,506,250q�6e    50      �� *	IsChecked+# [ $4 .MaterialDesignOutlinedTextBoxTextCountComboBox��52   e   �� 53      -   5        $ tx_province��53      $��85��6/   #��[ 54      $
	 Wrap=�55      $

 Auto=�57      $ Province��58      $��Javanese Text)�6?   $��20(�6Z   $��506,365,30,250q�6h    56      �� *	IsChecked+# [ $4 .MaterialDesignOutlinedTextBoxTextCountComboBox��58   h   �� 59      -   5        $ tx_CP��59      $��85��6M   #��[ 5:      $
	 Wrap=�5;      $

 Auto=�5=      $ Code Postal��5>      $��Javanese Text)�6B   $��20(�6]   $��720,263,30,352q�6k   $ Arrow��6�    5<      �� *	IsChecked+# [ $4 .MaterialDesignOutlinedTextBoxTextCountComboBox��5>   �   �� 5?   
   -   5        $ 	tx_numTel��5?      $��85��6I   #��[ 5@      $
	 Wrap=�5A      $

 Auto=�5C      $ Numero de téléphone��5D      $��Javanese Text)�6J   $��20(�6e   $��30,489,500,126q�6s    5B      �� *	IsChecked+# [ $4 .MaterialDesignOutlinedTextBoxTextCountComboBox��5D   s   G� 5E   
   -	   5        $��tx_mdp��5E      $��520,489,30,126q�6$   $��85��6<    % !MaterialDesignOutlinedPasswordBox#��[ 5F      $ Mot de passe��5G      $��Javanese Text)�6G   $��20(�6b   �� 5H   
   -
   5        $ 
tx_couriel��5H      $��85��6&   #��[ 5I      $
	 Wrap=�5J      $

 Auto=�5L      $ Adresse Mail��5M      $��Javanese Text)�6C   $��20(�6^   $��30,597,500,18q�6l    5K      �� *	IsChecked+# [ $4 .MaterialDesignOutlinedTextBoxTextCountComboBox��5M   l   �� 5N   
   $��0,443,0,217q�6   $���-----------------CONTACT-------------------------------------------------------------------------------------------------------��6%   $��Javanese Text)�5O      $��20(�60   G� 5P   
   -   5         G�Name$ tx_mdpConfir��5P      $��520,597,30,18q�6,   $��85��6C   #��[ 5Q      $ Confirmer le mot de passe��5R      $��Javanese Text)�6H   $��20(�6c   �� 5S   
   -   5         " MaterialDesignRaisedDarkButton#��[ 5T      +  %MaterialDesignThemes.Wpf.ButtonAssist   CornerRadius$ 25��5U      $7 1MaterialDesignRaisedDarkButton with Round Corners��5V      $��50��5W   �   $��770,158,30,492q�6�   $
 Hand��6�   {�6   �� *DataContext.ControlsEnabled+ �� RelativeSource �� *FindAncestor+ �� AncestorType" �.��5X      �� $��	CONFIRMER��5Y      5Z      5[      5\      