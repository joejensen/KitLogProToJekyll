# KitLogProToJekyll

A tool to export the worklogs from a [Kit Log Pro](http://www.kitlog.com/) experimental aircraft build log into a set of posts and images that can be included on a [Jekyll](https://jekyllrb.com/) blog.

## Usage

![User Interface Screenshot](doc/KlpToJekyll.jpg)
The UI requires only 3 pieces of information:
1.  The location of the KitLog database
2.  The location of the Jekyll site.  Posts will be place in the _posts directory and images in the assets/images directory.
3.  An optional custom category for each each post.  If absent then the expense category from the build log will be used.

After the required fields are populated the Generate button causes the export, any prior exports will be overwritten.

