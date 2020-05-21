import SignIn from "./page/SignIn/SignIn";
import SignUp from "./page/SignUp/SignUp";
import React from 'react';
import {
  BrowserRouter as Router,
  Switch,
  Route,
} from "react-router-dom";

export const routes = [
    {
      path: "/",
      component: SignIn
    },
    {
      path: "/singup",
      component: SignUp
    }
  ];
  export function RouteWithSubRoutes(route: any) {
    return (
      <Route
        path={route.path}
        render={props => (
          // pass the sub-routes down to keep nesting
          <route.component {...props} routes={route.routes} />
        )}
      />
    );
  }
  