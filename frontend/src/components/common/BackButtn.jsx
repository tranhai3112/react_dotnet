import {useCallback} from 'react'
import {useNavigate} from 'react-router-dom'

const BackButtn = () => {
    const navigation = useNavigate()
    const goBack = useCallback(() => {
        navigation(-1)
    },[])
  return (
    <div className='btn' onClick={goBack} style={{display:"inline-block", marginTop:12}}>
      Go back
    </div>
  )
}

export default BackButtn
