import React from 'react'
import Dropzone from 'react-dropzone'
import PropTypes from 'prop-types'
import ButtonDelete from '../ButtonDelete/ButtonDelete';
import { Container } from '@material-ui/core';
import { useTranslation } from 'react-i18next';
import GetUserToken from '../../core/GetUserToken';

export default function FileUpload(props: any) {
  const { onUpload, fileName, fileId } = props;
  const { t } = useTranslation();
  const [stateFileName, setStateFileName] = React.useState(fileName)
  const [isDeleted, setIsDeleted] = React.useState(false);
  const onDeleteFile = () => {
    setStateFileName(null)
    setIsDeleted(true)
  }

  return (
    <Container maxWidth="xl">
      <Dropzone onDrop={acceptedFiles => {
        setStateFileName(acceptedFiles[0].name);
        onUpload(acceptedFiles)
      }}>
        {({ getRootProps, getInputProps }) => (
          <section>
            <div {...getRootProps()}>
              <input {...getInputProps()} />
              <p>{t("DRAG_N_DROP_UPOAD")}</p>
            </div>
          </section>
        )}
      </Dropzone>
      <p>{stateFileName === "" ? fileName : stateFileName}
        {(fileName !== null  && isDeleted === false) &&
          <ButtonDelete DeleteUrl={"webportal/FileUpload/FileDelete?accessToken=" + GetUserToken() + "&objectId=" + fileId} DeleteDialogTitle={t("FILE_DELETE_TITLE")}
            DeleteDialogContent={t("FILE_DELETE_CONTENT")} onDelete={onDeleteFile}
          />}
      </p>
    </Container>
  );
}
FileUpload.prototype = {
  onUpload: PropTypes.func.isRequired,
  fileName: PropTypes.string,
  fileId: PropTypes.string
}