   M S B A M L   `   `   `  ����A  =Lab_09, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:Lab_09Lab_09  5   	       Lab_09.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   &localclr-namespace:Lab_09     5   	     � Title$  
MainWindow��5   	   $	��450��6   $	��800��6)    J� CommandBindings 5	      )  #System.Windows.Input.CommandBinding  5
   
   -   5           Command$ local:WindowCommands.Exit��5
      6=   .��5      �  � ColumnDefinitions 5   
   �� 5      $
��133* �6   �� 5      $
��661* �6   .+�5   
   � $��0��6   
�������.+�5      �� -   5         ��Name$ ListViewMenu��5      $
��0 50q�6-   
�������$	��240��6N   $	��Top=�6^   $ �� IsSynchronizedWithCurrentItem$
 TrueY�5      $��Disabled=�6D   ��5   P   Z� ��6f   Z� .@�5      �� $��60��6   .��5      ��  �� Orientation$ 
Horizontal=�6!   .+�5      �� $��Center=�6$   $
��Main��6?   $��20(�6K   $��Global Sans Serif)�6Y   $��15,0,0,0q�6x   $
��Wrap=�6�   5      5      �� 5      $��60��6   .��5      �� $ 
Horizontal=�6!   .+�5      �� $��Control1��6$   $
��Wrap=�64   $��20(�6H   $��Global Sans Serif)�6V   $��15,0,0,0q�6u   $��Center=�6�   5      5       �� 5!      $��60��6   .��5"      �� $ 
Horizontal=�6!   .+�5$      �� $��Control2��6$   $
��Wrap=�64   $��20(�6H   $��Global Sans Serif)�6V   $��15,0,0,0q�6u   $��Center=�6�   5%      5&      5'      5(      � 5*   
   -   5         �Name$ GridPrincipal��5*      $��1��6   5,      5-      5.      