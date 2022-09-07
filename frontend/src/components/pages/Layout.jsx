import React from 'react'
import Navigation from '../container/Navigation'
import {Outlet} from 'react-router-dom'

const Layout = () => {
  return (
    <>
     <Navigation/>
     <div className='container'>
      <Outlet/> 
     </div>
    </>
  )
}

export default Layout
