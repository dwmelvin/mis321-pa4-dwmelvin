  const url = "https://localhost:7198/api/Exercise";
  let myExercises = [];

  async function handleOnLoad() {
    let response = await fetch(url);
    myExercises = await response.json();
    console.log(myExercises);

    document.getElementById("form").style.display = "none";

    let html = `
      <h1 id="tidefit-header">TideFit</h1>
      <h2 id="workout-log-header">Workout Log</h2>
      <h6 id="motto-statement"> Level Up Your Fitness and Stay Consistent</h6>
      <td>
      <button type="Add Exercise Button" class="Add Exercise" onclick="showForm()">Add Exercise</button>
      </td>
          <table class="table table-striped ">
              <tr> 
                  
                  <th>Exercise Type</th>
                  <th>Exercise Duration</th>
                  <th>Exercise Date</th>
                  <th>Pin</th>
                  <th>Delete</th>
              </tr>`;
  
    myExercises.sort(
      (a, b) => Date.parse(b.exerciseDate) - Date.parse(a.exerciseDate)
    );
    myExercises.forEach(function (exercise) {
      if (exercise.delete === false) {
        const pinText = exercise.pinned ? "Pinned" : "Pin";
        const backgroundColor = exercise.pinned
          ? "rgba(0, 0, 255, 0.5)"
          : "Transparent";
        const borderStyle = exercise.pinned ? "solid 2px red" : "none";
        html += `
              <tr>
              <td class="vertical-line">${exercise.exerciseType}</td>
              <td class="vertical-line">${exercise.exerciseDuration}</td>
              <td class="vertical-line">${exercise.exerciseDate}</td>
              <td class="vertical-line"><button type="button" id="unpinned-btn-${exercise.exerciseID}" class="btn btn-Pin" style="background-color: ${backgroundColor}; border: ${borderStyle};" onclick="handleExercisePin(${exercise.exerciseID}, ${exercise.pinned})">${pinText}</button></td>
              <td class="vertical-line"><button type="button" id="deleted-btn-${exercise.exerciseID}" class="btn btn-Delete" style="background-color: red; color: white;" onclick="handleExerciseDelete(${exercise.exerciseID})">Delete</button></td>
          </tr>`;
      }
    });
    html += `</table>`;
    document.getElementById("app").innerHTML = html;
  }

  async function handleExerciseDelete(referenceExerciseID) {
    let exercise = {exerciseID: referenceExerciseID, exerciseDate: "", exerciseDuration:"", exerciseType: "", pinned: false, delete: true};
    await fetch(url, {
      method: "DELETE",
      body: JSON.stringify(exercise),
      headers: {
        "Content-type": "application/json; charset=UTF-8",
      },
    });
    await handleOnLoad();
  }

  async function handleExercisePin(referenceExerciseID, referencePinned) {
    console.log(referencePinned);
    let exercise = {exerciseID: referenceExerciseID, exerciseDate: "", exerciseDuration:"", exerciseType: "", pinned: referencePinned, delete: false};

    await fetch(url, {
      method: "PUT",
      body: JSON.stringify(exercise),
      headers: {
        "Content-type": "application/json; charset=UTF-8",
      },
    });

    handleOnLoad();
  }

  async function handleExerciseAdd() {

    let exercise = {
      ExerciseType: document.getElementById("exercisetype").value,
      ExerciseDuration: document.getElementById("exerciseduration").value,
      ExerciseDate: document.getElementById("exercisedate").value,
      Delete: false,
      Pinned: false,
    };
    myExercises.push(exercise);

    await fetch(url, {
      method: "POST",
      body: JSON.stringify(exercise),
      headers: {
        "Content-type": "application/json; charset=UTF-8",
      },
    });
    handleOnLoad();
  }

  async function saveExercise() {
    let exercise = {
      ExerciseID: generateUniqueID(),
      ExerciseType: document.getElementById("exercisetype").value,
      ExerciseDuration: document.getElementById("exerciseduration").value,
      exerciseDate: document.getElementById("exercisedate").value,
      Delete: false,
      Pinned: false,
    };
    console.log("saveExercise", exercise);
    await fetch(url, {
      method: "POST",
      body: JSON.stringify(exercise),
      headers: {
        "Content-Type": "application/json; charset=utf-8",
      },
    });
  }

  function generateUniqueID() {
    return Math.floor(Math.random() * 2000);
  }

  function showForm() {
    document.getElementById("form").style.display = "block";
  }
