# CS4540 A3

[Github Link](https://github.com/kenmingwang/CS4540)

---

## Note
- Home page is the Overview page, where only the first Collapseable-Card is dynamic (pulling data from DB), the rest of the cards are just static for there to show the Collapseable feature, since we don't have that much data.
- Progress bar now is generated randomly, to show some variants of the table.
- The two controller-actions are listed in the homepage, one is "ControllerGenerate" and the other is "ViewGenerate", they have the same output but different ways to render.

## Razor paragraphs

Comparing to passing a "HTML" string from controller, it makes more sense to write HTML code in a HTML file. It's more easy to edit since the highlights and indentations are all valid within the cshtml file. It's also nice to make things more standalone, where C# code goes to C# files and HTML code goes to HTML files. It will be easier for later-on debugging as well.

However, there are useful cases to use viewdata when you need information that's not within the Model object for that controller. Say I have the Course and I need this Courses' Learning outcome from another table. Then it make sense to use C# code to query the Learning Outcomes and then store it to viewdata and to render it as Razor syntas in the HTML file.


## Improvements 

Nothing really, spent most of the time figuring out the assignment. Will do improvements when we actually integrate the database into the HTML files that we created earlier.
