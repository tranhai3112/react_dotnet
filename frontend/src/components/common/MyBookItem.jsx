import React from 'react'
import Devider from './Devider'
import {useRemovePersonBook} from '../../api/PersonBook/personBookHook'
import { useCallback } from 'react'

const MyBookItem = ({book}) => {
  const removePersonBook = useRemovePersonBook()
  const onRemove = useCallback(() => {
    removePersonBook.mutate(book?.id)
  },[])
  return (
    <div className='store-item'>
        <div className='store-item-header'>
          <h4>{book.name}</h4>
          <p>${book.price}</p>
        </div>
        <Devider/>
        <div className='store-item-content'>
          <p>{book.descripion}</p>
          <div className='store-item-option'>
            <div className='btn btn-danger' onClick={onRemove}>
              Remove
            </div>
          </div>
        </div>
    </div>
  )
}

export default MyBookItem
