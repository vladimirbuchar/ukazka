import React from 'react';
import { Container } from '@material-ui/core';

export default function LogOut() {
    window.sessionStorage.clear();
    window.location.href="/";
    
 return (
  <Container component="main" maxWidth="xs">
      
</Container>
  );
}