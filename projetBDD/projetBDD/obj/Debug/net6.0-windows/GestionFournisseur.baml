   M S B A M L   `   `   `  ����D  @projetBDD, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:projetBDD	projetBDD  5   	   "    projetBDD.GestionFournisseur   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:projetBDD     5   	   _ [MaterialDesignThemes.Wpf, Version=4.5.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	      MaterialDesignBody#���   5	   	   $��Regular"�5
   	   $��13(�5   	   &   System.Windows.Media.TextOptions    TextFormattingMode$  Ideal=�5   	      TextRenderingMode$
 Auto=�5   	     MaterialDesignPaper#���  5   	     MaterialDesignFont#���  5   	    � Title$ GestionFournisseur��5   	   $	��700��6$   $
��1000��61    � AllowsTransparency$
 True��6>    � WindowStyle$
 None=�6X   .��5      � .+�5   
   �� $��GESTION FOURNISSEURS��6   $��30(�6/   $��Javanese Text)�6=   $��300,0,300,620q�6X   �� 5   
   -   5        $��bt_exit��5       / +MaterialDesignFloatingActionMiniLightButton#��[ 5       � ToolTip$ Fermer la fenêtre��5      $��960,-650,0,0q�6V    � Cursor$
 Hand��6�   ��6)   Z� ��6?   Z� .��5      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ CloseCircle=�5      $��21��6$   $��30��60   5      �� 5   
   -   5        $��	bt_retour��5       . *MaterialDesignFloatingActionMiniDarkButton#��[ 5      $ Page précédente��5      $
��Auto��6@   $
��Auto��6N   ���	#DD000000���	#FFD5D4D9���	#DD000000$
 Hand��6�   $��10,10,950,649q�6�   .��5        $ 	ArrowBack=�5      5      �� 5   
   -   5         ��Name$ cbFournisseur��5      $
��Left=�6+   $��167,106,0,0q�6F   $	��Top=�6[   $	��160��6s   $��46��6   &   System.Windows.Controls.DataGrid  5    
   -   5        $��dgFournisseur��5       $
��Left=�6)   $	��265��6D   $��
62,197,0,0q�6Q   $	��Top=�6e   $	��872��6}   6�   �� 5!   
   -   5        #��[ 5"      $ 
Rechercher��5#      $��396,112,564,548q�6"   ���	#FFE5E4E4���	#FFE5E4E4���	#DD000000	 J� RenderTransformOrigin$	 
0.715,0.91&�6�   $
��Auto��6�   $
��Auto��6�   .��5$        $ Magnify=�5%      $��30��6    $��22��6,   5&      �� 5'   
   -   5        $��
lsid_siret��5'      $
��Left=�6%   $��37��6@   $��
90,538,0,0q�6L   
 �� TextWrapping$

 Wrap=�6`   $	��Top=�6t   $	��120��6�   ${�False��6�   �� 5(   
   -   5        $��lsid_adresse��5(      $
��Left=�6'   $��37��6B   $��252,538,0,0q�6N   $

 Wrap=�6c   $	��Top=�6w   $	��120��6�   ${�False��6�   �� 5)   
   -   5        $��lsnom_entreprise��5)      $
��Left=�6+   $��37��6F   $��445,538,0,0q�6R   $

 Wrap=�6g   $	��Top=�6{   $	��120��6�   ${�False��6�   �� 5*   
   -	   5        $��lscontact_fournisseur��5*      )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ contact��60   $
��Left=�6Y   $��37��6t   $��635,538,0,0q�6�   $

 Wrap=�6�   $	��Top=�6�   $	��120��6�   �� 5+   
   -
   5        $��lslibelle_fournisseur��5+      $ libellé��60   $
��Left=�6Y   $��37��6t   $��814,538,0,0q�6�   $

 Wrap=�6�   $	��Top=�6�   $	��120��6�   �� 5,   
   -   5        $��Modifier��5,      $
��Left=�6$   $��396,608,0,0q�6?   $	��Top=�6T   $	��198��6l   6x   �� 5-   
   -   5        $��	Supprimer��5-      $
��Left=�6%   $��675,608,0,0q�6@   $	��Top=�6U   $	��199��6m   6y   �� 5.   
   -   5        $��Exporter en XML/JSON��5.      $
��Left=�60   $��150,608,0,0q�6K   $	��Top=�6`   $	��177��6x   6�   50      51      