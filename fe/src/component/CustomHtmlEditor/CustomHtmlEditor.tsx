import React from 'react';
import { Editor } from '@tinymce/tinymce-react';
import PropTypes from 'prop-types';


export default function CustomHtmlEditor (props:any) {
    const {content,onChangeContent} = props;
    const handleEditorChange = (content:any, editor:any) => {
        onChangeContent(content);
      }
    return (
        <Editor
        initialValue={content}
        apiKey="zz4n465utf5nl4h4tpaj3na8qlxu8bdbmvg1ck3qgt3i6s7u"
        init={{
          height: 500,
          menubar: false,
          plugins: [
            'advlist autolink lists link image charmap print preview anchor',
            'searchreplace visualblocks code fullscreen',
            'insertdatetime media table paste code help wordcount'
          ],
          toolbar:
            'undo redo | formatselect | bold italic backcolor | \
            alignleft aligncenter alignright alignjustify | \
            bullist numlist outdent indent | removeformat | help'
        }}
        onEditorChange={handleEditorChange}
      />
    );
  }
  CustomHtmlEditor.prototype = {
    content: PropTypes.string,
    onChangeContent: PropTypes.func
}