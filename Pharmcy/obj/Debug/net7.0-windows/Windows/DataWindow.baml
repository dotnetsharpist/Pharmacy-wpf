   M S B A M L   `   `   `  ����B  >Pharmcy, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:Pharmcy.WindowsPharmcy.Windows  5   	        Pharmcy.Windows.DataWindow   5   	   W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:Pharmcy.Windows     5   	   -   5          � 
ResizeMode$  NoResize=�5	   	    � Title$ 
DataWindow��5
   	   $	��467��6   $	��800��6)   .��5      � $��0,0,0,39q�6    � RowDefinitions 5   
   �� 5      $��5* �6   �� 5      $��* �6   .+�5   
   �� $��0��6   
������ .+�5      �� $��5 5 0 5q�6   $��1��5      $	��300��6(   .��5      &   System.Windows.Controls.DataGrid  -   5          Name$ 
MyDataGrid��5         
IsReadOnly$
 True��6/   ���#001C30 � 	Resources 5      =  7System.Windows.Controls.Primitives.DataGridColumnHeader �� 
TargetType �� Property   SecondaryBackground �� Value��%�   '        �� 5      "  6    .�5      ��  � ��# �   6;   �� 5       � ��$ 18(�69   �� 5       � ��$ JetBrains Mono)�6;   �� 5       � ��$ SemiBold"�6;   �� 5       � ��$ 2q�6@   5      5      	   Columns	 5!      5%      5+      54      � 55   
   $��1��6   
������ .+�56      �� -   5        
 ��Name$
 btnSAVE��56      $	��PAY��6&   $	��200��65   $��315,0,285,0q�6W     SuccessButton#���  6l   �� 57      -   5         ��Name$ ozodbek��57   �   $��Label��6   $
��Left=�6$   $��
655,10,0,0q�6?   $	��Top=�6S   $��18(�6k   $��JetBrains Mono)�6y   $��SemiBold"�6�   6�   58      59      5;      