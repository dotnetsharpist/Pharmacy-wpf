   M S B A M L   `   `   `  ����B  >Pharmcy, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:Pharmcy.PagesPharmcy.Pages  5          Pharmcy.Pages.ReportPage   5      W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      -localclr-namespace:Pharmcy.Pages     5        N� Title$  
ReportPage��5
      .��5      � ���#64CCC5 � RowDefinitions 5   
   �� 5      $��47 �6   �� 5      $��* �6   .+�5   
   �� -   5         ��Name$ outputFiles��5         SuccessButton#���   6&   $��Print��6N   $	��200��6^   $��30��6j   6v   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ DataGridcha��5      $��1��5         
IsReadOnly$
 True��5      ���#001C30 � 	Resources 5      =  7System.Windows.Controls.Primitives.DataGridColumnHeader �� 
TargetType �� Property  SecondaryBackground �� Value��%�   '        �� 5      "  6   .�5      ��  � ��# �  63   �� 5       � ��$ 18(�61   �� 5       � ��$ JetBrains Mono)�63   �� 5       � ��$ SemiBold"�63   �� 5       � ��$ 2q�68   5      5      	   Columns	 5       0  *System.Windows.Controls.DataGridTextColumn  5!      ,  &System.Windows.Controls.DataGridColumn
   Header$
 Category��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$	 100 6W      FontSize$ 16Q�6d      
FontFamily$ JetBrains Mono)�6r      
FontWeight$ SemiBold"�6�   1  +System.Windows.Controls.DataGridBoundColumn   Binding 67   �� *MedCategory+6�     5"      $

 Name��6%   $	 100 6L   $ 16Q�6X   $ JetBrains Mono)�6f   $ SemiBold"�6�    63   �� *Name+6�     5#      $
 Price��6%   $ 90 6N   $ 16Q�6Y   $ JetBrains Mono)�6g   $ SemiBold"�6�    64   �� *Price+6�     5$      $
 CreatedTime��6%   $	 125 6X   $ 16Q�6d   $ JetBrains Mono)�6r   $ SemiBold"�6�    6:   �� *	CreatTime+6�     5%      $
 EndTime��6%   $	 125 6R   $ 16Q�6_   $ JetBrains Mono)�6m   $ SemiBold"�6�    66   �� *	EndTime+6�     5&      $
 	CreatedAt��6%   $ * 6V   $ 16Q�6a   $ JetBrains Mono)�6o   $ SemiBold"�6�    68   �� *	CreatedAT+6�   5(      5)      5+      