   M S B A M L   `   `   `  ����D  @projetBDD, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:projetBDD	projetBDD  5   	       projetBDD.Gestion_clients   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:projetBDD     5   	   _ [MaterialDesignThemes.Wpf, Version=4.5.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	      MaterialDesignBody#���   5	   	   $��Regular"�5
   	   $��13(�5   	   &   System.Windows.Media.TextOptions    TextFormattingMode$  Ideal=�5   	      TextRenderingMode$
 Auto=�5   	     MaterialDesignPaper#���  5   	     MaterialDesignFont#���  5   	    � Title$ Gestion_clients��5   	   $	��700��6!   $
��1000��6.    � AllowsTransparency$
 True��6;    � WindowStyle$
 None=�6U   .��5      � .+�5   
   �� $!��        GESTION D'UN CLIENT��6   $��30(�66   $��Javanese Text)�6D   $��300,0,254,620q�6_   �� 5   
   -   5        $��bt_exit��5       / +MaterialDesignFloatingActionMiniLightButton#��[ 5       � ToolTip$ Fermer la fenêtre��5      $��960,-650,0,0q�6V   ��6)   Z� ��6?   Z� .��5      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ CloseCircle=�5      $��21��6$   $��30��60   5      �� 5   
   -   5        $��	bt_retour��5       . *MaterialDesignFloatingActionMiniDarkButton#��[ 5      $ Page précédente��5      $
��Auto��6@   $
��Auto��6N   ���	#DD000000���	#FFD5D4D9���	#DD000000 � Cursor$
 Hand��6�   $��10,10,950,649q�6�   .��5        $ 	ArrowBack=�5      5      �� 5   
   -   5        $��Supprimer client��5      $
��Left=�6,   $��300,611,0,0q�6G   $	��Top=�6\   $	��172��6t   6�   �� 5    
   $��Ligne selectionnée :��6   $
��Left=�6/   $��
10,512,0,0q�6J   $	��Top=�6^   $	��143��6v   $
��Bold"�6�   �� 5!   
   -   5        $��lscontact_clients��5!      )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ contact��6,   $
��Left=�6U   $��23��6p   $��314,548,0,0q�6|   	 �� TextWrapping$
	 Wrap=�6�   $	��Top=�6�   $	��120��6�   
 J� RenderTransformOrigin$
 1.377,0.443&�6�   �� 5"   
   -   5        $��
lsadhesion��5"      $ adhesion��6%   $
��Left=�6O   $��23��6j   $��472,548,0,0q�6v   $
	 Wrap=�6�   $	��Top=�6�   $	��120��6�   �� 5#   
   -   5         ��Name$ tbnom_clients��5$      .  (MaterialDesignThemes.Wpf.TextFieldAssist   HasClearButton$
 True��5%      $	 Nom��5&      $��212,60,636,595q�5'      ��6%   �� *Name+ �� UpdateSourceTrigger$ PropertyChanged=��� 5(   
   -   5        $ tbprenom_clients��5)      $
 True��5*      $ Prénom��5+      $��435,60,402,595q�5,      ��6%   �� *Name+$ PropertyChanged=��� 5-   
   -   5        $��
Rechercher��5-      $
��Left=�6&   $��
702,68,0,0q�6A   $	��Top=�6U   $	��225��6m   $��43��6y   6�   &   System.Windows.Controls.DataGrid  5.   
   -	   5        $��	dgClients��5.      $
��Left=�6%   $	��376��6@   $��
10,113,0,0q�6M   $	��Top=�6a   $	��910��6y   6�   �� 5/   
   -
   5        $��Modifier��5/      $
��Left=�6$   $��559,611,0,0q�6?   $	��Top=�6T   $	��163��6l   6x   �� 50   
   -   5        $ lsnom_clients��50      $	 nom��6*   $
��Left=�6O   $��23��6j   $��148,548,0,0q�6v   $
	 Wrap=�6�   $	��Top=�6�   $	��120��6�   $
 1.377,0.443&�6�   ${�False��6�   �� 51   
   -   5        $ lsid_clients��51      $ id��6)   $
��Left=�6M   $��23��6h   $��
18,548,0,0q�6t   $
	 Wrap=�6�   $	��Top=�6�   $	��120��6�   $
 1.377,0.443&�6�   ${�False��6�   $ Arrow��6�   �� 52   
   -   5        $��adhesion��52      $
��Left=�6$   $��817,611,0,0q�6?   $	��Top=�6T   $	��163��6l   6x   �� 53   
   -   5        $��Exporter en XML/JSON��53      $
��Left=�60   $��
47,611,0,0q�6K   $	��Top=�6_   $	��184��6w   6�   54      55      