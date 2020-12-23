import { api } from './AxiosService'
import { AppState } from '../AppState'

class JobContractorService {
  async getContractorsByJob(jobId) {
    try {
      const res = await api.get('api/jobs/' + jobId + '/contractorjobs')
      AppState.jobContractors = res.data
    } catch (e) {
      console.log(e)
    }
  }
}

export const jcService = new JobContractorService()
