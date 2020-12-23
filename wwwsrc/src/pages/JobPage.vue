<template>
  <div class="jobPage container-fluid">
    <div class="row">
      <div class="col-4">
        <h3 class="align-self-center">
          {{ jobs.title }}
        </h3>
        <h5>{{ jobs.location }}</h5>
        <p class="align-self-center">
          {{ jobs.budget }}
        </p>
      </div>
    </div>
    <div class="row">
      <h2>Current Contractors on Job</h2>
      <job-contractor v-for="contractor in contractors" :key="contractor.id" :job-contractor-prop="contractor" class="col-8" />
    </div>
  </div>
</template>

<script>
import { computed, onMounted } from 'vue'
import { AppState } from '../AppState'
import { jcService } from '../services/JobContractorService'
export default {
  name: 'JobPage',
  props: ['jobProp'],
  setup(props) {
    onMounted(async() => {
      await jcService.getContractorsByJob(AppState.activeJob.id)
    })
    return {
      contractors: computed(() => AppState.jobContractors),
      jobs: computed(() => AppState.activeJob)
    }
  },
  components: {}
}
</script>

<style lang="scss" scoped>

</style>
