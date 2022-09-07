import { useState, useEffect } from 'react'
import {useParams} from 'react-router-dom'
import { useBook } from '../../api/Book/bookHooks'
import BackButtn from '../common/BackButtn'
import {useUpdateBook} from '../../api/Book/bookHooks'
import {useNavigate} from 'react-router-dom'

const BookDetails = () => {
    const params = useParams()
    const navigation = useNavigate()
    const {data:book, isSuccess} = useBook(params?.id)
    const updateBook = useUpdateBook()
    const [formData, setFormData] = useState({
      name:'',
      descripion:'',
      price:0,
      id:null
    })
    
    useEffect(() => {
      setFormData(book)
    },[isSuccess === true])

    const onChangeBook = (e) => {
      const id = e.target.id
      const value = e.target.value
      setFormData(prevState => {
        return {...prevState, [id] : value}
      })
    }
    const onUpdateBook = () => {
      updateBook.mutate(formData)
      navigation('/')
    }
  return (
    <>
        <BackButtn />
        <div className='book-edit'>
        <div className='book-edit-form'>
          <div className='form-input'>
          <input type="text" name='name' 
          placeholder='name' id='name' onChange={onChangeBook} value={formData?.name || ""}/>
          </div>
          <div className='form-input'>
          <input type="text" name='descripion' 
          placeholder='description' id='descripion' onChange={onChangeBook} value={formData?.descripion|| ""}/>
          </div>
          <div className='form-input'>
          <input type="number" name='price' 
          placeholder='price' id='price' min={0} onChange={onChangeBook} value={formData?.price|| 0} />
          </div>
          <div className='btn btn-info' style={{textAlign:'center'}} onClick={onUpdateBook}>
            submit
          </div>
        </div>
        
        </div>
    </>
    
  )
}

export default BookDetails
