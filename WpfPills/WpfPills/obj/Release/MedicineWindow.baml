   M S B A M L   `   `   `  ����   WpfPills    TheMozyer.MedicineWindow   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml       � Title$  
MainWindow��$
��1366��$	��768�� � WindowStyle$
 None=� � AllowsTransparency . .��� ����  �� EndPoint$ 0.5,1&� �� 
StartPoint$ 0.5,0&�.���  � Color$ 	#FF00CFCF�� � Offset$ 1Q�� $ White��$ 0.239Q�� $ 	#FFC5F4F4��$ 0.486Q�.+��� -   $��	Emergency��$��	EMERGENCY��$
��Left=�$��1128,430,0,0q�$	��Top=�$	��220��$	��320��
���  ��$��30(�$
��Bold"�
��������� -   $��
Medication��$��0q�#��[" �$
��Left=�$��1128,220,0,0q�$	��Top=�$	��220��$	��200��$��25(�.���� $��images/SelectBottle.png��$	��190��$	��220��$
��Fill=��� -   $��Vitals��$��0q�#��[" �$
��Left=�$��1128,10,0,0q�$	��Top=�$	��220��$	��200��$��25(�.���� $��images/SelectVitals.jpg��$	��200��$	��220��$
��Fill=��� -   $��Settings��
������ $
��Left=�$��
15,664,0,0q�$	��Top=�$	��100��$��85��$��25(���Z� .���� $��settings.png��$
��Fill=��� -   $
��Home��
������ $
��Left=�$��120,664,0,0q�$	��Top=�$	��100��$��85��$��25(���Z� .���� $��home.png��$
��Fill=��� $
��Left=�$��75��$��	15,10,0,0q� �� TextWrapping$
 Wrap=�$4��.WARNING: BLOOD GLUCOSE LEVELS LOW, EAT A SNACK��$	��Top=�$
��1070��$��42(���Z� ��Z� �� -   $
��time��$
��Left=�$��84��$��221,665,0,0q�$
 Wrap=�$
��Time��$	��Top=�$	��304��$��45(���Z� ��Z� �� -   $
��date��$
��Left=�$��84��$��530,665,0,0q�$
 Wrap=�$
��Date��$	��Top=�$	��555��$��45(���Z� ��Z� �� $��2q�._�� $
��Left=�$	��569��$��	15,90,0,0q�$	��Top=�$
��1070�� � RowDefinitions �� $	��45* ��� $	��75* ��� $
��105* ��� $
��135* ��� $
��165* �	 � ColumnDefinitions	 �� $	��35* ��� $	��54* ��� $	��65* ��� $	��60* �.+��� -   $��takenHeader��$��0��$��0��$��30(�$��Center=�.��Taken�� -	   $��
timeHeader��$��1��$��0��$��30(�$��Center=�.��Time to Take�� -
   $��
pillHeader��$��2��$��0��$��30(�$��Center=�.��Pill�� -   $��
doseHeader��$��3��$��0��$��30(�$��Center=�.��Dose�� -   $��
firstTaken��$��0��$��1��$��30(�$��Center=�$��Center=�$��18��
 d� 	IsChecked$

 TrueY� � LayoutTransform ��  �� ScaleX$ 2Q� �� ScaleY$ 2Q��� -   $��	firstTime��$��1��$��1��$��30(�$��Center=�$��Center=�.��
10:00 AM�� -   $��	firstPill��$��2��$��1��$��30(�$��Center=�$��Center=�.��	Tylenol�� -   $��	firstDose��$��3��$��1��$��30(�$��Center=�$��Center=�.��	2 Pills�� -   $��secondTaken��$��0��$��2��$��30(�$��Center=�$��Center=�$��18��$

 TrueY� �� $ 2Q�$ 2Q��� -   $��
secondTime��$��1��$��2��$��30(�$��Center=�$��Center=�.��
10:00 AM�� -   $��
secondPill��$��2��$��2��$��30(�$��Center=�$��Center=�.��	Dayquil�� -   $��
secondDose��$��3��$��2��$��30(�$��Center=�$��Center=�.��1 Pill�� -   $��
thirdTaken��$��0��$��3��$��30(�$��Center=�$��Center=�$��18�� �� $ 2Q�$ 2Q��� -   $��	thirdTime��$��1��$��3��$��30(�$��Center=�$��Center=�.��	2:00 PM�� -   $��	thirdPill��$��2��$��3��$��30(�$��Center=�$��Center=�.��Vitamin Supplement�� -   $��	thirdDose��$��3��$��3��$��30(�$��Center=�$��Center=�.��1 Pill�� -   $��fourthTaken��$��0��$��4��$��30(�$��Center=�$��Center=�$��18�� �� $ 2Q�$ 2Q��� -   $��
fourthTime��$��1��$��4��$��30(�$��Center=�$��Center=�.��
10:00 PM�� -   $��
fourthPill��$��2��$��4��$��30(�$��Center=�$��Center=�.��Nyquil�� -   $��
fourthDose��$��3��$��4��$��30(�$��Center=�$��Center=�.��1 Pill&   System.Windows.Controls.DataGrid  -     Name$ dataGrid��$
��Left=�$��345,462,0,0q�$	��Top=�