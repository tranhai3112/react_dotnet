import {useCallback} from 'react'
import { useDeleteBook } from '../../api/Book/bookHooks'
import {useAddPersonBook} from '../../api/PersonBook/personBookHook'
import {useNavigate} from 'react-router-dom'
import Devider from './Devider'

const BookItem = ({book}) => {
  const navigation = useNavigate()
  const deleteBook = useDeleteBook()
  const addPersonBook = useAddPersonBook()
  const onRemove = useCallback(() =>{
    deleteBook.mutate(book?.id)
  },[])
  const onDetail = useCallback(() =>{
    navigation(`books/${book?.id}`)
  },[])
  const onMoveToMyBook = () => {
    addPersonBook.mutate([book?.id])
    navigation('my-books')
  }
  return (
      <div className='book-item'>
        <div className='book-item-header'>
          <h4>{book.name}</h4>
          <p>${book.price}</p>
        </div>
        <Devider/>
        <div className='book-item-content'>
          <div className='book-item-content-info' style={{marginBottom: book.descripion ? 50:0}}>
            <p>{book.descripion}</p>
          </div>
          <div className='book-item-content-option'>
            <div className='btn btn-danger' onClick={onRemove}>
              Remove  
            </div>
            <div className='btn btn-info' onClick={onDetail}>
              Details
            </div>
            <div className='btn ' onClick={onMoveToMyBook}>
              Add
            </div>
          </div>
        </div>
      </div>
  )
}

export default BookItem
