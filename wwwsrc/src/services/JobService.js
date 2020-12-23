import { AppState } from '../AppState'
import { api } from './AxiosService'

class JobService {
  async getAll() {
    try {
      const res = await api.get('api/jobs')
      console.log(res.data)
      AppState.jobs = res.data
    } catch (err) {
      console.log(err)
    }
  }

  setActive(jobData) {
    AppState.activeJob = jobData
  }
}

export const jobService = new JobService()
