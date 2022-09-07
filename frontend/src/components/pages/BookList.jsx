import { useBooks } from '../../api/Book/bookHooks'
import useRQGlobalState from '../../hooks/customUseQuery';
import { key } from '../../hooks/customUseQuery';
import BookItem from '../common/BookItem';
import Modal from '../common/Modal';


const BookList = () => {
  const {data:books} = useBooks();
  const [, setVisible] = useRQGlobalState(key.MODAL_ADD_BOOK, false)
  const toggleModalAddBook = () => {
    setVisible(prevState => !prevState)
  }
  return (
    <>
      <div className='book-list-nav'>
        <div className='btn btn-info' onClick={toggleModalAddBook}>
          Add
        </div>
      </div>
      <div className='book-item-wrapper'>
      
      {books?.map((book, index) => {
        return (
            <BookItem key={index} book={book}/>
        )
      })}
      </div>
      <Modal/>
    </>
    
  )
}

export default BookList
