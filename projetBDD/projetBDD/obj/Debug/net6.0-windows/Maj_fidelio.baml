   M S B A M L   `   `   `  ����D  @projetBDD, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:projetBDD	projetBDD  5   	       projetBDD.Maj_fidelio   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:projetBDD     5   	   _ [MaterialDesignThemes.Wpf, Version=4.5.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	      MaterialDesignBody#���   5	   	   $��Regular"�5
   	   $��13(�5   	   &   System.Windows.Media.TextOptions    TextFormattingMode$  Ideal=�5   	      TextRenderingMode$
 Auto=�5   	     MaterialDesignPaper#���  5   	     MaterialDesignFont#���  5   	    � Title$ Maj_fidelio��5   	   $	��700��6   $
��1000��6*    � AllowsTransparency$
 True��67    � WindowStyle$
 None=�6Q   .��5      � .+�5   
   �� $��SOUSCRIPTION FIDELIO��6   $��30(�6/   $��Javanese Text)�6=   $��300,0,300,620q�6X   �� 5   
   -   5        $��bt_exit��5       / +MaterialDesignFloatingActionMiniLightButton#��[ 5       � ToolTip$ Fermer la fenêtre��5      $��960,-650,0,0q�6V   ��6)   Z� ��6?   Z� .��5      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ CloseCircle=�5      $��21��6$   $��30��60   5      �� 5   
   -   5        $��	bt_retour��5       . *MaterialDesignFloatingActionMiniDarkButton#��[ 5      $ Page précédente��5      $
��Auto��6@   $
��Auto��6N   ���	#DD000000���	#FFD5D4D9���	#DD000000 � Cursor$
 Hand��6�   $��10,10,950,649q�6�   .��5        $ 	ArrowBack=�5      5      �� 5   
   -   5        $��
st_fidelio��5      $��8,201,8,291q�6'   $	��208��6<   $	��983��6I   .+�5       �� -   5        $��	ck_normal��5       $��Center=�5!      $��	30,0,70,0q�5"      $��52��6,   $��Javanese Text)�5#      $��20(�64   $]��W  Fidelio                |    Coût : 15€     |   Durée : 1 An     |   Rabais de 5 %��6B    d� 	IsChecked 5!   4   �� *
IsSelected+5#   B   �� 5$      -   5        $��ck_or��5$   8   $��52��5%      $��	30,0,70,0q�6%   $��Javanese Text)�5&      $��20(�64   $Y��S  Fidelio Or           |    Coût : 25€    |   Durée : 2 Ans   |   Rabais de 8 %��6B    5$      �� *
IsSelected+5&   B   �� 5'      -   5        $��
ck_platine��5'   8   $��52��5(      $��	30,0,70,0q�6%   $��Javanese Text)�5)      $��20(�64   $W��Q  Fidelio Platine   |    Coût : 60€    |   Durée : 2 Ans   |   Rabais de 10 %��6B    5'      �� *
IsSelected+5)   B   �� 5*      -   5        $��ck_max��5*   8   $��52��5+      $��	30,0,70,0q�6%   $��Javanese Text)�5,      $��20(�64   $W��Q  Fidelio Max        |   Coût : 100€   |   Durée : 3 Ans   |   Rabais de 12 %��6B    5*      �� *
IsSelected+5,   B   5.      �� 5/   
   -   5         " MaterialDesignRaisedDarkButton#��[ 50      +  %MaterialDesignThemes.Wpf.ButtonAssist	   CornerRadius$	 25��51      $7 1MaterialDesignRaisedDarkButton with Round Corners��52      $��50��53   �   $��770,620,30,30q�6�   $
 Hand��6�   {�6   �� *DataContext.ControlsEnabled+
 �� RelativeSource
 �� *FindAncestor+ �� AncestorType" �.��54      �� $��	CONFIRMER��55      56      57      58      