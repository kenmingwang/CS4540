# CS4540 PS5


### Ken Wang 
[Github Link](https://github.com/kenmingwang/CS4540)

---

## Note
- There's two courses that seeded with notes, can be found in homepage under the "DepartmentChair" column
- User roles page can now actually change roles of users, user can also gain multiple roles or no roles.
- Modified the course detail page to show Course notes and LOS notes. 
    - Course notes:
        1. Only Instructors can edit. It's a inline WYSIWYG editor so just click and edit, then save.
        2. A tag on top will flag whether it's approved by a chair or not.
        3. Chair can approve notes when there is a pending note to be approved.
        4. Chair CANNOT edit course notes.
    - LOS notes:
        1. Click the "show comments" on the "Evalutaion Metric" column to see comments.
        2. Both the class Instructor and chair is able to edit the inline note editor.
        3. If the text in the note is red, it was lastly edited by a chair, else it's edited by Instructor.
- Added a button for every course in DetailsProfessor page to redirect to the actual course detail page to see the notes.
- Everything will be updated asynchronously.


## Advanced Features Compeleted

- :heavy_check_mark: (2pts) Date stamp the note and show this information next to the note.
    - Datestamp and the person who edited is shown on the bottom right of the course note section.
- :heavy_check_mark: (3pts) Allow a chair to approve the note and mark that it was seen.
    - Chair will be able to approve notes that are pending.
- :heavy_check_mark: Instead of a plain textarea, use a WYSIWYG editor. 
    - Used CKEditor for the light-weighted inline rich-text fucntionality.
-  :heavy_check_mark:

## Above and Beyond

- At register time, I made the user to put their First and Last name to register, so that now instead of having "Professor professor_mary@cs.utah.edu" , we got "Professor Mary Hall". Which is much nicer to everyone.
- Courses are listed in Numeric order, just a programmer habbit. Though it needs to be in Chronical order later...
- I think I did well on the Role Status page, where I really like this UI I tried out. It's straight forward and it looks cool! I would like the Admin page to look more deep and dark, because it's always more serious to be a Admin...
- Also the "bonus karma" (a list of all courses an instructor is teaching) mentioned in the Assignment is what I've done for Above and Beyond.


## Improvements 
- Now it's using "Migration-based" DB instialization, instead of using database.ensureCreated. 
- Made ALL the UI pages dynamic pulling from the database and transfered it to the UI I made for A1/A2. (Except for the static data to show the "collapsible" functionality in course list)
- Improved the footer so that when there's less content in the page it won't go to the middle of the page but will stay at the "bottom"
- Improved Create for LOS to have the user select "Course Names" instead of "CourseCid".
- Removed all the hard-coded "routes" and all links are now Controller based.
- Changed some UI some all pages should all look like a simliar style.

## Next-Step
- Make Admin life easier to beautify a little on the CRUD pages. Considering to integrate LOS CRUD to Course CRUD, so Admin can directly edit LOSs in a Course, instead have to go to LOS CRUD.
- More seeds to display the "Collapsible"
