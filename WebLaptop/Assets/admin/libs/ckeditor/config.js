/**
 * @license Copyright (c) 2003-2019, CKSource - Frederico Knabben. All rights reserved.
 * For licensing, see https://ckeditor.com/legal/ckeditor-oss-license
 */

CKEDITOR.editorConfig = function (config) {
    // Define changes to default configuration here. For example:
    // config.language = 'fr';
    // config.uiColor = '#AADC6E';

    config.filebrowserBrowseUrl = '/Assets/admin/libs/ckfinder/ckfinder.html',
    config.filebrowserUploadUrl = '/Assets/admin/libs/ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Files',
    config.filebrowserWindowWidth = '1000',
    config.filebrowserWindowHeight = '700'
};
