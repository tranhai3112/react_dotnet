import React from 'react'
import {Link} from 'react-router-dom'

const Navigation = () => {
  return (
    <div className='nav-wrapper'>
        <div className='container'>
            <div className='nav'>
                <div className='brand'>
                    <Link to='/' >Store</Link>
                    <Link to='/my-books' >My Books</Link>
                </div>
                <div className='nav-footer'>
                    <p>username</p>
                </div>
            </div>
        </div>
    </div>
  )
}

export default Navigation
