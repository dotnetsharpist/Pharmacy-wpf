   M S B A M L   `   `   `  ����B  >Pharmcy, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:PharmcyPharmcy  5   	       Pharmcy.MainWindow   5   	   W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:Pharmcy     5   	     � Title$  
MainWindow��5   	   $	��650��5	   	   $
��1000��5
   	    � WindowStartupLocation$ CenterScreen=�5   	    � WindowStyle$
 None=�5   	    � 
ResizeMode$ NoResize=�5   	   
������  � AllowsTransparency$
 True��5   	   .��5      �  � RowDefinitions 5   
   �� 5      $��40 �6   �� 5      $��* �6   .+�5   
   �� $��0��6   
���   � �� CornerRadius$ 	10 10 0 0��5      ���#64CCC5$��0 0 0 3q�5      ._�5      � $��	10 0 10 0q�6    � ColumnDefinitions 5      �� 5      $��* �6'   �� 5      $	��100 �6'   .+�5      �� -   5         ��Name$ 
brDragable��5      $��0��5!      
���   �	 � Cursor$	 	ScrollAll��5#      5%      �� 5&      $��1��6   
 �� Orientation$
 
Horizontal=�6-   .+�5'      �� -   5         ��Name$ BtnMinimaze��5'         MinimizeButton#���   6L   �� 5(      -   5        $ BtnMaximaze��5(        MaximazedButton#���  6K   �� 5)      -   5        $ BtnClose��5)        CloseButton#���  6F   5*      5+      5,      � 5-   
   $��1��6    5.      �� 5/      $	��250 �6#   �� 50      $��* �6#   .+�52      �� $��0��6   ���#001C30$ 0 0 0 10��54      ._�55      �� $��0 20 0 0q�6   .+�56      	� -   5         	�Name$ 
rbCustomer��57        
MenuButton#���  58      $��Customer��59      $��18(�5:        Customer
 � Tag# �  5<      6:   	� 5>      -   5        $ 
rbMedicine��5>   "   #���  5?   "   $��Medicine��5@   "   $��18(�5A   "     Medicine# �  5C   "   6C   	� 5E      -   5        $ rbPharmacist��5F      #���  5G      $��
Pharmacist��5H      $��18(�5I        
Pharmacist# �  5K      6<   	� 5M      -   5        $ rbPurchasing��5N      #���  5O      $��
Purchasing��5P      $��18(�5Q        
Purchasing# �  5S      	� 5U      -	   5        $ rbReport��5V      #���  5W      $��Report��5X      $��18(�5Y       
 Report# �  5[      	� 5]      -
   5        $ rbInformation��5^      #���  5_      $��Infomration��5`      $��18(�5a       	 informations# � 	 5c      6>   	� 5e      -   5        $ rbAbout��5f      #���  5g      $��About��5h      $��18(�5i       	
 about# � 
 5k      67   5n      5o      �� 5p      $��1��6   ���#176B87$ 0 0 10 0��5r      ._�5s       � -   5          �Name$ PageNavigator��5s        � NavigationUIVisibility$ Hidden=�5t      ��5u      �� 5v       �� ImageSource$ Assets/Images/rasm.png��6%   5x      5y      5z      5{      5|      