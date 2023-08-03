# CustomEditor

Bu projede Angular mimarisinin directive özelliği ile geliştirdiğim bir Blog Editörü sizlere sunuyorum.

## Server Bağlantısı

Bu projeye özel geliştirdiğim [Custom-Editor-Server](https://github.com/muraterennar/custom-editor-server).

## Yapılması Gerekenler

- `npm install` komutunu çalıştırın.

## Editor Directive Yapısı

Bu [Directive'de](https://github.com/muraterennar/custom-editor/blob/master/src/app/directives/editor.directive.ts) editorun tüm özelliklerinin ekliyoruz.

## Directiv'in Kullanıldığı Yer

[blog.component.html](https://github.com/muraterennar/custom-editor/blob/master/src/app/admin/admin-components/blog/blog.component.html) içinde `<div class="container" customEditor></div>` tagında kullanılmıştır.

`<div id="editor" class="editor-container p-3 mt-4 border"></div>` editor id'li div içinde oluşturulan blog'u görebilmekteyiz.

