   M S B A M L   `   `   `  ����D  @projetBDD, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:projetBDD	projetBDD  5   	       projetBDD.Accueil   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:projetBDD     5   	   _ [MaterialDesignThemes.Wpf, Version=4.5.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	      MaterialDesignBody#���   5	   	   $��Regular"�5
   	   $��13(�5   	   &   System.Windows.Media.TextOptions    TextFormattingMode$  Ideal=�5   	      TextRenderingMode$
 Auto=�5   	     MaterialDesignPaper#���  5   	     MaterialDesignFont#���  5   	    � Title$ Accueil��5   	   $	��700��6   $
��1000��6&    � AllowsTransparency$
 True��63    � WindowStyle$
 None=�6M   .��5      � ���	#FFE5E4E4.+�5   
   �� $��ACCEUIL��6   $��30(�6"   $��Javanese Text)�60   $��400,0,400,620q�6K   �� 5   
   -   5        $��bt_exit��5       / +MaterialDesignFloatingActionMiniLightButton#��[ 5       � ToolTip$ Fermer la fenêtre��5      $��960,-650,0,0q�6V   ��6)   Z� ��6?   Z� .��5      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ CloseCircle=�5      $��21��6$   $��30��60   5      �� 5   
   -   5        $��bt_notif��5      $��50��6!   $	��300��6-   $��20(�69   $��Javanese Text)�6G     MaterialDesignRaisedButton#��[ 5      3  -MaterialDesignThemes.Wpf.ButtonProgressAssist   Value$ -1Q�5         IsIndicatorVisible$
 True��5      	   IsIndeterminate$
	 True��5      $��STOCK��5      $��570,-450,100,0q�5      {�5       �� *DataContext.ControlsEnabled+
 �� RelativeSource
 �� *FindAncestor+ �� AncestorType
 Window6�   �� 5!   
   -   5        $��
bt_clients��5!      $��50��6#   $	��300��6/   $��Javanese Text)�6;    " MaterialDesignRaisedDarkButton#��[ 5"      +  %MaterialDesignThemes.Wpf.ButtonAssist   CornerRadius$ 25��5#      $��100,200,550,400q�5$   �   ���	#FFD7CECE���	#FF030000���	#FFD7CECE{�6   �� *DataContext.ControlsEnabled+
 �� *FindAncestor+
 Window.��5%      �� $��GERER LES CLIENTS��5&      $��20(�6*   5'      �� 5(   
   -   5        $��bt_Commandes��5(      $��50��6%   $	��300��61   $��Javanese Text)�6=   #��[ 5)      $ 25��5*      $��550,200,100,400q�5+   �   ���	#FFD7CECE���	#FFD7CECE���	#FF000001{�6   �� *DataContext.ControlsEnabled+
 �� *FindAncestor+
 Window.��5,      �� $��GERER LES COMMANDES��5-      $��20(�6,   5.      �� 5/   
   -   5        $��bt_produits��5/      $��50��6$   $	��300��60   $��Javanese Text)�6<   #��[ 50      $ 25��51      $��100,300,550,300q�52   �    � Cursor$
 Hand��6�   ���	#FFD7CECE���	#FFD7CECE���	#DD000000{�6   �� *DataContext.ControlsEnabled+
 �� *FindAncestor+
 Window.��53      �� $��GERER LES PRODUITS��54      $��20(�6+   55      �� 56   
   -   5        $��bt_fournisseurs��56      $��50��6(   $	��300��64   $��Javanese Text)�6@   #��[ 57      $ 25��58      $��550,300,100,300q�59   �   $
 Hand��6�   ���	#FFD7CECE���	#FFD7CECE���	#DD000000{�6   �� *DataContext.ControlsEnabled+
 �� *FindAncestor+
 Window.��5:      �� $��GERER LES FOURNISSEURS��5;      $��20(�6/   5<      �� 5=   
   -   5         ��Name$ bt_stat��5=      $��50��6"   $	��300��6.   $��Javanese Text)�6:   #��[ 5>      $ 25��5?      $ Statistiques��5@      $��349,459,351,191q�5A   �   $
 Hand��6�   ���	#FFD7CECE���	#DD000000���	#FFD7CECE{�6   �� *DataContext.ControlsEnabled+
 �� *FindAncestor+" �.��5B      �� $��STATISTIQUES��5C      $��20(�6%   5D      5E      5F      