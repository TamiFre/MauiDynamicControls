using Kotlin.Text;
using MauiApp2;
using Microsoft.Maui.Controls.PlatformConfiguration;

namespace MauiDynamicControls;

public partial class DynamicControlsPage : ContentPage
{
    List<Monkey> monkeys;
    //int countup = 0;
    //int countdown = 0;
    int counter = 0;
    public DynamicControlsPage()
    {
        InitializeComponent();
        //הוספת הפקדים בצורה דינאמית
        InitializeControlls();
        monkeys = Monkey.GetMonkeys();
    }

    private void InitializeControlls()
    {
        //Add your Code Here

        AddLayout();  //הוסף פריסה

        AddImage();//הוסף את תווית

        AddButtons(); //הוסף כפתורים



    }

    private void AddLayout()
    {
        //יצירת פריסה חדשה
        StackLayout stackLayout = new StackLayout();
        //לאורך או לרוחב
        stackLayout.Orientation = StackOrientation.Vertical;
        //רווח
        stackLayout.Padding = new Thickness(30, 0);
        //המרחק בין הפקדים בתוך הפריסה
        stackLayout.Spacing = 25;
        stackLayout.BackgroundColor = Colors.Brown;

        //מיקום ביחס למסך
        stackLayout.VerticalOptions = LayoutOptions.Center;
        //הצבת הפקד בתוך המסך
        this.Content = stackLayout;

    }
    private Image AddImage()
    {
        //יצירת הפקד
        //Label lbl = new Label()
        //{
        //    HorizontalOptions = LayoutOptions.Center,
        //    Text = "התחלה",
        //    FontSize = 12


        //};
        //StackLayout stk = (StackLayout)this.Content;
        //stk.Children.Add(lbl);
        ////OnPlatform....=>DeviceInfo.Current.Platform=DevicePlatform....
        // DevicePlatform OnPlatform = DeviceInfo.Current.Platform;
        //if (OnPlatform == DevicePlatform.Android || OnPlatform == DevicePlatform.iOS)
        //    lbl.FontSize = 15;
        //else
        //    lbl.FontSize = 25;

        Image img = new Image()
        {
            Source = "https://raw.githubusercontent.com/jamesmontemagno/app-monkeys/master/baboon.jpg"//התמונה של הזה במקום הראשון
        };
        StackLayout stk = (StackLayout)this.Content;
        stk.Children.Add(img);
        return img;

        //הוספת הפקד למסך
        //הערה: ניתן להגדיר שהפעולה הנוכחית מחזירה את הפקד החדש שנוצר 
        //ונגדיר פעולה נוספת המקבלת רשימת פקדים ומוסיפה אותם לפריסה



    }

    //כפתורים
    private void AddButtons()
    {
        //נאתר את הפריסה
        StackLayout stk = (StackLayout)this.Content;
        //ניצור כפתור 1==="\uef7d"
        Button upBtn = new Button()
        {
            HorizontalOptions
        = LayoutOptions.Center,
            Text = "לחץ למעלה"

        };
        //הוספת איקון לכפתור
        upBtn.ImageSource = new FontImageSource()
        {
            FontFamily = "MaterialSymbolsSharp",
            Glyph = "\uef7d",
            Color = Color.FromHex("#db1442")
        };
        //הרשמה לאירוע
        upBtn.Clicked += ClickedUpEvent;

        //כפתור 2
        //"\ue941"

        Button downBtn = new Button()
        {
            HorizontalOptions
       = LayoutOptions.Center,
            Text = "לחץ למטה"

        };
        //הוספת איקון לכפתור
        downBtn.ImageSource = new FontImageSource()
        {
            FontFamily = "MaterialSymbolsSharp",
            Glyph = "\uef7d",
            Color = Color.FromHex("#db1442")
        };
        //הרשמה לאירוע
        //הרשמה לאירוע באמצעות anoymous functions =>
        downBtn.Clicked += ClickedDownEvent;


        //חיבור הפקדים לLAYOUT
        stk.Children.Insert(0, upBtn);
        stk.Children.Add(downBtn);
    }

    private void ClickedUpEvent(object sender, EventArgs e)
    {
        counter++;
        StackLayout stk = new StackLayout();
        if (counter >= monkeys.Count())
        {
            //deactivate the up button
            ((Button)stk.Children[0]).IsEnabled = false;
            counter--;
        }
        ((Image)stk.Children[1]).Source = monkeys[counter].Image;
        // reactivate the down button
        ((Button)stk.Children[2]).IsEnabled = true;


    }

    private void ClickedDownEvent(object sender, EventArgs e)
    {
        StackLayout stk = new StackLayout();
        counter--;
        if (counter < 1)
        {
            // deactivate the down button
            ((Button)stk.Children[2]).IsEnabled = false;
            counter++;
        }
        ((Image)stk.Children[1]).Source = monkeys[counter].Image;
        ((Button)stk.Children[0]).IsEnabled = true;
        // reactivate the up button
    }


    //private void ClickedUpEvent(object sender, EventArgs e)
    //{
    //    Button bt = (Button)sender; //הכפתור שעשה את הפעולה
    //    countup++;
    //    if (countup >= monkeys.Count())//אם אין יותק תמונות
    //    {
    //        bt.IsEnabled = false;
    //        AddImage().Source =monkeys[countup].Image;
    //    }
    //    else 
    //    {
    //        bt.IsEnabled = true;
    //    }
    //}

    //private void ClickedDownEvent(object sender, EventArgs e)
    //{
    //    Button bt = (Button)sender;
    //    countdown--;
    //    if (countdown <= 1)
    //    {
    //        bt.IsEnabled = false;
    //        AddImage().Source = monkeys[countdown].Image;
    //    }
    //    else 
    //    {
    //        bt.IsEnabled = true;
    //    }
    //}

    //private void ClickedUpEvent(object sender, EventArgs e)
    //{
    //    Button bt = (Button)sender;
    //    countup++;
    //    if (countup >= monkeys.Count())
    //    {
    //        downBtn.IsEnabled = true;
    //        bt.IsEnabled = false;
    //    }
    //    else
    //    {
    //        AddImage().Source = monkeys[countup].Image;
    //        downBtn.IsEnabled = true;
    //    }


    //}

    //private void ClickedDownEvent(object sender, EventArgs e)
    //{
    //    Button bt = (Button)sender;
    //    countdown--;
    //    if (countdown <= 1)
    //    {
    //        bt.IsEnabled = false;
    //        AddImage().Source = monkeys[countdown].Image;
    //    }
    //    else
    //    {
    //        AddImage().Source = monkeys[countdown].Image;
    //        downBtn.IsEnabled = true;
    //    }

    //}
}