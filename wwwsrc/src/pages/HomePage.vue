<template>
  <div class="home flex-grow-1 d-flex flex-column align-items-center justify-content-center">
    <h3>
      Jobs
    </h3>
    <p>
      <jobs-component v-for="job in jobs" :key="job.Id" :job-prop="job" />
    </p>
  </div>
</template>

<script>
import { computed, onMounted, reactive } from 'vue'
import { AppState } from '../AppState'
import { jobService } from '../services/JobService'
import JobsComponent from '../components/Home/JobsComponent'
export default {
  name: 'Home',
  setup(props) {
    onMounted(() => {
      jobService.getAll()
    })
    const state = reactive({
      newJob: {}
    })
    return {
      state,
      jobs: computed(() => AppState.jobs)
    }
  },
  components: { JobsComponent }
}
</script>

<style scoped lang="scss">
.home{
  text-align: center;
  user-select: none;
  > img{
    height: 200px;
    width: 200px;
  }
}
</style>
