   M S B A M L   `   `   `  ����A  =Lab_06, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:Lab_06Lab_06  5          Lab_06.SearchControl   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      b ^MaterialDesignThemes.Wpf, Version=4.0.0.2422, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5       localclr-namespace:Lab_06  5      -   5          >�Name$  userControl��5   -   .��5      �  � RowDefinitions 5   
   �� 5      $��0.35* �6   �� 5      $��2* �6   �� 5      $
��1.1* �6    � ColumnDefinitions 5   
   �� 5      $
��0.3* �6   �� 5      $��1* �6   .+�5   
   � $��0��6   .+�5      �� -   5         ��Name$ Buttonn��5      $	��Top=�6&      	m_Buttons#���   6>   .��6w   Delete6   5      � 5   
   $��1��6   $��2��6   .+�5      ?  9MaterialDesignThemes.Wpf.Transitions.TransitioningContent  C  =MaterialDesignThemes.Wpf.Transitions.TransitioningContentBase   OpeningEffect 62   D  >MaterialDesignThemes.Wpf.Transitions.TransitionEffectExtension  *SlideInFromLeft+   Duration$ 0:0:0.8X�.��5      �� -   5         ��Name$ partList��5      $��Disabled=�6-   $��0q�6c   ��5      �� 5      .R�5      ��  ��Name$ panel��6]    �� Orientation$ 
Horizontal=�6)   $��Bottom=�6B   .+�5   "   �� .+�5   &   �� $��Cooper Black)�6K   ���	#FF151717��60   �� 	 �� Path$
	 Name�6e   �� 5    &   $��10q�61   .+�5!   *   �� $��50(�6P   $��Cooper Black)�6^   ���	#FF1D1212��64   �� $	 Price�6x   �� 5"   *   $��25(�6S   $��Champagne & Limousines)�6a   $
��Bold"�6�   $��5q�6�   ��64   �� $	 Quantity�6�   �� 5#   *   $��20(�6V   $��Champagne & Limousines)�6d   $��5q�6�   ��64   �� $	 Description�6�   �� 5$   *   $��18(�64   $	��150��6B   $��Champagne & Limousines)�6N   $��5q�6v   $
��Wrap=�6�   ��6�   �� $	 FullDiscription�5&   +   5'   '   5(   #   �� 5)   "   $��10q�6(   $	��200��64   $	��200��6@   ��6M   �� $	 	ImagePath�5*      5+      5-      5.      5/      � 50   
   $��2��6   $��0��6   $��2��6,   .+�51      �� .+�52      �� .+�53      �� $��Center=�6      MaterialDesignTextBlock#���  6=     m_Search#���  6o   6�   �� 54      -   5        
 ��Name$

 name��54        MaterialDesignTextBox#���  6,   6^   55      �� 56      $ Vertical=�6   .+�57      �� -   5        $
 UpPrice��57      #���  6/   $	��100��6_   $
��Left=�6k   6�   �� 58      -   5        $
 BottomPrice��58      #���  63   $	��100��6c   $
��Left=�6o   6�   �� 59      -   5        $ SearchB��59      $��Search��6.   $	��100��6?   #���   6K   6�   5:      5;      5<      5>      5?      