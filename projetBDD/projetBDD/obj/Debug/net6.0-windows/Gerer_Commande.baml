   M S B A M L   `   `   `  ����D  @projetBDD, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:projetBDD	projetBDD  5   	       projetBDD.Gerer_Commande   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:projetBDD     5   	   _ [MaterialDesignThemes.Wpf, Version=4.5.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	      MaterialDesignBody#���   5	   	   $��Regular"�5
   	   $��13(�5   	   &   System.Windows.Media.TextOptions    TextFormattingMode$  Ideal=�5   	      TextRenderingMode$
 Auto=�5   	     MaterialDesignPaper#���  5   	     MaterialDesignFont#���  5   	    � Title$ Gerer_Commande��5   	   $	��700��6    $
��1000��6-    � AllowsTransparency$
 True��6:    � WindowStyle$
 None=�6T   .��5      � .+�5   
   �� $��GERER LES COMMANDES��6   $��30(�6.   $��Javanese Text)�6<   $��300,0,300,620q�6W   �� 5   
   -   5        $��bt_exit��5       / +MaterialDesignFloatingActionMiniLightButton#��[ 5       � ToolTip$ Fermer la fenêtre��5      $��960,-650,0,0q�6V   ��6)   Z� ��6?   Z� .��5      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ CloseCircle=�5      $��21��6$   $��30��60   5      �� 5   
   -   5        $��	bt_retour��5       . *MaterialDesignFloatingActionMiniDarkButton#��[ 5      $ Page précédente��5      $
��Auto��6@   $
��Auto��6N   ���	#DD000000���	#FFD5D4D9���	#DD000000 � Cursor$
 Hand��6�   $��10,10,950,649q�6�   .��5        $ 	ArrowBack=�5      5      �� 5   
   -   5        $��	bt_mesCmd��5      $��50��6"   $	��300��6.    " MaterialDesignRaisedDarkButton#��[ 5       +  %MaterialDesignThemes.Wpf.ButtonAssist   CornerRadius$ 25��5!      $7 1MaterialDesignRaisedDarkButton with Round Corners��5"      $��350,-100,350,0q�5#   �   {�6   �� *DataContext.ControlsEnabled+	 �� RelativeSource	 �� *FindAncestor+
 �� AncestorType

 Window.��5$      �� $��MES COMMANDES��5%      $��20(�6&   5&      �� 5'   
   -   5        $��bt_cmdClient��5'      $��50��6%   $	��300��61   #��[ 5(      $ 25��5)      $7 1MaterialDesignRaisedDarkButton with Round Corners��5*      $��140,418,560,232q�5+   �   $
 Hand��6�   {�6   �� *DataContext.ControlsEnabled+	 �� *FindAncestor+

 Window.��5,      �� $��SUIVIS COMMANDES��5-      $��20(�6)   5.      �� 5/   
   -   5         ��Name$ bt_passeCmd��5/      $��50��6&   $	��300��62   #��[ 50      $ 25��51      $7 1MaterialDesignRaisedDarkButton with Round Corners��52      $��350,543,350,107q�53   �   $
 Hand��6�   {�6   �� *DataContext.ControlsEnabled+	 �� *FindAncestor+"
 �.��54      �� $��PASSER COMMANDE��55      $��20(�6(   56      �� 57   
   -   5        $ bt_fairecmdClient��57      $��50��6,   $	��300��68   #��[ 58      $ 25��59      $7 1MaterialDesignRaisedDarkButton with Round Corners��5:      $��605,418,95,232q�5;   �   $
 Hand��6�   {�6   �� *DataContext.ControlsEnabled+	 �� *FindAncestor+"
 �.��5<      �� $��PASSER COMMANDE CLIENT��5=      $��20(�6/   5>      5?      5@      