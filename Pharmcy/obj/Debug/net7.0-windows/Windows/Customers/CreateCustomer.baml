   M S B A M L   `   `   `  ����B  >Pharmcy, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:Pharmcy.Windows.CustomersPharmcy.Windows.Customers  5   	   .    (Pharmcy.Windows.Customers.CreateCustomer   5   	   W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   9local'clr-namespace:Pharmcy.Windows.Customers     5   	     � Title$  Add new Customer��5       � 
ResizeMode$ NoResize=�5	   	    � WindowStartupLocation$ CenterScreen=�5
   	   $	��420��5   	   $	��700��6    � 	Resources 5         
TitleLabel �� 
TargetType �� Property �� Value��%�   &	        �� 5   
   " ��6#   .�5      ��  � �� �#64CCC56+   �� 5       � ��$ Jetbrains Mono)�6+   �� 5       � ��$ 16(�6)   �� 5       � ��$ SemiBold"�6+   �� 5       � ��$	 0 5q�6'   5      5      .��5      � ���#001C30.+�5   
   ��  �� Orientation$ Vertical=�6   $��20q�5      .+�5      �� $
��Name��6   #���   6#   �� 5       �� CornerRadius$ 10��6     SecondaryBackground#���  5      $��25��5      ._�5      �� -   5        	 ��Name$	 tbFirstName��5      
 �� 	MaxLength$
 50��5      $��1��5      $��Center=�5      $��16(�5       $��	10 0 10 0q�5!      $��Jetbrains Mono)�5"      $��0q�5#      
�������#���  5%      6M   5'      �� 5(      $��Surname��6   #���   6&   �� 5)      $ 10��6   #���  5*      $��25��5+      ._�5,      �� -   5        $	 
tbLastName��5,      $
 50��5-      $��1��5.      $��Center=�5/      $��16(�50      $��	10 0 10 0q�51      $��JetBrains Mono)�52      $��0q�53      
�������#���  55      57      �� 58      $	��Age��6   #���   6"   �� 59      $ 10��6   #���  5:      $��25��5;      $	��100��5<      $
��Left=�5=      ._�5>      �� -   5        $	 tbAge��5>      $
 2��5?      $��1��5@      $��16(�5A      $��	10 0 10 0q�5B      $��JetBrians Mono)�5C      $��0q�5D      
����������#A9A9A95F      5G      �� 5H      $��Phone Number��6   #���   6+   �� 5I      $ 10��5J      #���  5K      $	��200��5L      $
��Left=�5M      $��25��5N      ._�5O      �� -   5        $	 tbPhoneNumber��5O      $
 13��61   $��1��5P      $��16(�5Q      $��	10 0 10 0q�5R      $��JetBrains Mono)�5S      $��0q�5T      
����������#A9A9A95V      5W      �� 5X      -   5         ��Name$ btnSave��5X      $��	0 20 0 10q�5Z      $��50��5[        SuccessButton#���  5\      $
��Save��6=   5]      5^      5_      