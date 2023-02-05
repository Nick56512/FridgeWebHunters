import React, { Component } from 'react';
import { Route, Routes } from 'react-router-dom';
import AppRoutes from './AppRoutes';
import Navigation from './organisms/Navigation';
import './styles/css/index.css'

export default class App extends Component {
  static displayName = App.name;

  render() {
    return (
      <div>
       <Navigation/>
       <div>
          <Routes>
            {AppRoutes.map((route, index) => {
              const { element, ...rest } = route;
              return <Route key={index} {...rest} element={element} />;
            })}
          </Routes>
        </div>
      </div>
    );
  }
}
