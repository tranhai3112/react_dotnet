import React from 'react'
import BackButton from '../common/BackButtn'
import MyBookItem from '../common/MyBookItem'
import { useShowPersonBook } from '../../api/PersonBook/personBookHook' 
const Mybooks = () => {
  const {data:person_books} = useShowPersonBook()
  return (
    <>
    <BackButton/> 
    <div className='store'>
        {person_books?.map((item, index) => {
          return (
            <MyBookItem key={index} book={item}/>
          )
        })}
    </div>
    </>
    
  )
}

export default Mybooks
