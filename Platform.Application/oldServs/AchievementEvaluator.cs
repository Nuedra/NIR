var result = new List<AchievementResult>();

foreach (var achievement in achievements)
{
    // Уже получена
    if (student.StudentAchievements.Any(sa => sa.AchieveID == achievement.Id))
    {
        result.Add(new AchievementResult
        {
            AchievementId = achievement.Id,
            Status = AchievementStatus.Opened
        });
        continue;
    }

    // ===== БАЗОВАЯ ВЕРТИКАЛЬ ПРОГРЕССА =====

    if (Student ) //(все по 0, только начал)
    {
        result.Add(new AchievementResult { AchievementId = 1, Status = AchievementStatus.Available });
        continue;
    }

    if (Student.labs.lab1 > 15)
    {
        result.Add(new AchievementResult { AchievementId = 2, Status = AchievementStatus.Available });
        continue;
    }

    if ((double)Student.CompletedTasks / Student.TotalTasks >= 0.5)
    {
        result.Add(new AchievementResult { AchievementId = 3, Status = AchievementStatus.Available });
        continue;
    }

    if (Student.labs.lab1 > 15 && Student.labs.lab2 > 15 && Student.labs.lab3 > 15 && Student.labs.lab4 > 15)
    {
        result.Add(new AchievementResult { AchievementId = 4, Status = AchievementStatus.Available });
        continue;
    }

    // ===== ПОСЕЩАЕМОСТЬ =====

    if (Student.Attendence.Lecture1 == 1)
    {
        result.Add(new AchievementResult { AchievementId = 5, Status = AchievementStatus.Available });
        continue;
    }

    if ((double)student.Attendence.Total >= 0.7)
    {
        result.Add(new AchievementResult { AchievementId = 6, Status = AchievementStatus.Available });
        continue;
    }

    if ((double)student.Attendence.Total == 1)
    {
        result.Add(new AchievementResult { AchievementId = 7, Status = AchievementStatus.Available });
        continue;
    }

    // ===== МАССИВЫ И СПИСКИ =====

    if (Student.labs.name =="arrays" && Student.labs.lab1 > 15)
    {
        result.Add(new AchievementResult { AchievementId = 8, Status = AchievementStatus.Available });
        continue;
    }

    if (Student.labs.name =="lists" && Student.labs.lab2 > 15)
    {
        result.Add(new AchievementResult { AchievementId = 9, Status = AchievementStatus.Available });
        continue;
    }

    if (Student.labs.name =="arrays" && Student.labs.name =="lists" && Student.labs.lab3 > 15)
    {
        result.Add(new AchievementResult { AchievementId = 10, Status = AchievementStatus.Available });
        continue;
    }

    if (Student.labs.name =="sequence" && Student.labs.lab4 > 15)
    {
        result.Add(new AchievementResult { AchievementId = 11, Status = AchievementStatus.Available });
        continue;
    }

    // ===== ОЧЕРЕДИ / ДЕКОНСТРУКЦИЯ =====

    if (Student.labs.name =="queues" && Student.labs.lab1 > 15)
    {
        result.Add(new AchievementResult { AchievementId = 12, Status = AchievementStatus.Available });
        continue;
    }

    if (Student.labs.name =="queues" && Student.labs.lab2 > 15)
    {
        result.Add(new AchievementResult { AchievementId = 13, Status = AchievementStatus.Available });
        continue;
    }

    if (Student.labs.name =="queues" && Student.labs.lab3 > 15)
    {
        result.Add(new AchievementResult { AchievementId = 14, Status = AchievementStatus.Available });
        continue;
    }

    if (Student.labs.name =="queues" && Student.labs.lab4 > 15)
    {
        result.Add(new AchievementResult { AchievementId = 15, Status = AchievementStatus.Available });
        continue;
    }

    if (student.labs.name == "queues" && Student.labs.lab1 > 15 && Student.labs.lab2 > 15 && Student.labs.lab3 > 15 && Student.labs.lab4 > 15)
    {
        result.Add(new AchievementResult { AchievementId = 16, Status = AchievementStatus.Available });
        continue;
    }

    // ===== ВЕКТОРЫ / МНОГОМЕРНОСТЬ =====

    if (student.labs.name == "matrix" && Student.labs.lab1 > 15)
    {
        result.Add(new AchievementResult { AchievementId = 17, Status = AchievementStatus.Available });
        continue;
    }

    if (student.labs.name == "vector" && Student.labs.lab2 > 15)
    {
        result.Add(new AchievementResult { AchievementId = 18, Status = AchievementStatus.Available });
        continue;
    }

    if (student.labs.name == "polynomial" && Student.labs.lab3 > 15)
    {
        result.Add(new AchievementResult { AchievementId = 19, Status = AchievementStatus.Available });
        continue;
    }

    if (student.labs.name == "dimension" && Student.labs.lab4 > 15)
    {
        result.Add(new AchievementResult { AchievementId = 20, Status = AchievementStatus.Available });
        continue;
    }

    // ===== МАТРИЦЫ =====

    if (student.labs.name == "matrix" && Student.labs.lab1 > 15)
    {
        result.Add(new AchievementResult { AchievementId = 21, Status = AchievementStatus.Available });
        continue;
    }

    if (student.labs.name == "matrix" && Student.labs.lab2 > 15)
    {
        result.Add(new AchievementResult { AchievementId = 22, Status = AchievementStatus.Available });
        continue;
    }

    if (student.labs.name == "matrix" && Student.labs.lab3 > 15)
    {
        result.Add(new AchievementResult { AchievementId = 23, Status = AchievementStatus.Available });
        continue;
    }

    if (student.labs.name == "matrix" && Student.labs.lab4 > 15)
    {
        result.Add(new AchievementResult { AchievementId = 22, Status = AchievementStatus.Available });
        continue;
    }

    if (student.labs.name == "matrix" && Student.labs.lab1 > 15 && Student.labs.lab2 > 15 && Student.labs.lab3 > 15 && Student.labs.lab4 > 15)
    {
        result.Add(new AchievementResult { AchievementId = 23, Status = AchievementStatus.Available });
        continue;
    }

    // ===== MAP / REDUCE / FILTER =====

    if (student.labs.name == "map" && Student.labs.lab1 > 15)
    {
        result.Add(new AchievementResult { AchievementId = 24, Status = AchievementStatus.Available });
        continue;
    }

    if (student.labs.name == "reduce" && Student.labs.lab2 > 15)
    {
        result.Add(new AchievementResult { AchievementId = 25, Status = AchievementStatus.Available });
        continue;
    }

    if (student.labs.name == "filter" && Student.labs.lab3 > 15)
    {
        result.Add(new AchievementResult { AchievementId = 26, Status = AchievementStatus.Available });
        continue;
    }

    // ===== АЛГОРИТМЫ И ТЕОРИЯ =====

    if (student.labs.name == "recursion" && Student.labs.lab1 > 15)
    {
        result.Add(new AchievementResult { AchievementId = achievement.Id, Status = AchievementStatus.Available });
        continue;
    }

    if (student.labs.name == "partial_order" && Student.labs.lab2 > 15)
    {
        result.Add(new AchievementResult { AchievementId = achievement.Id, Status = AchievementStatus.Available });
        continue;
    }

    if (student.labs.name == "graph" && Student.labs.lab3 > 15)
    {
        result.Add(new AchievementResult { AchievementId = achievement.Id, Status = AchievementStatus.Available });
        continue;
    }

    if (student.labs.name == "function_analysis" && Student.labs.lab4 > 15)
    {
        result.Add(new AchievementResult { AchievementId = achievement.Id, Status = AchievementStatus.Available });
        continue;
    }

    // ===== ТИПИЗАЦИЯ / ФИНАЛ =====

    if (achievement.Id == AchievementIds.MatrixTyping &&
        student.MatrixTypingUsed)
    {
        result.Add(new AchievementResult { AchievementId = achievement.Id, Status = AchievementStatus.Available });
        continue;
    }

    if (achievement.Id == AchievementIds.MultiDimensional &&
        student.Dimensions >= 3)
    {
        result.Add(new AchievementResult { AchievementId = achievement.Id, Status = AchievementStatus.Available });
        continue;
    }

    if (achievement.Id == AchievementIds.BaseMaster &&
        student.BaseTasksCompleted)
    {
        result.Add(new AchievementResult { AchievementId = achievement.Id, Status = AchievementStatus.Available });
        continue;
    }

    if (achievement.Id == AchievementIds.TheoryAlphabet &&
        student.TheoryModulesCompleted)
    {
        result.Add(new AchievementResult { AchievementId = achievement.Id, Status = AchievementStatus.Available });
        continue;
    }

    if (achievement.Id == AchievementIds.CourseCompleted &&
        student.CourseCompleted)
    {
        result.Add(new AchievementResult { AchievementId = achievement.Id, Status = AchievementStatus.Available });
        continue;
    }

    if (achievement.Id == AchievementIds.CourseMaster &&
        student.FinalScore >= 90)
    {
        result.Add(new AchievementResult { AchievementId = achievement.Id, Status = AchievementStatus.Available });
        continue;
    }

    if (achievement.Id == AchievementIds.CourseAce &&
        student.RankPercentile <= student.TopPercent)
    {
        result.Add(new AchievementResult { AchievementId = achievement.Id, Status = AchievementStatus.Available });
        continue;
    }

    if (achievement.Id == AchievementIds.CourseSlacker &&
        student.CourseCompleted && student.ActivityScore < student.MinActivityThreshold)
    {
        result.Add(new AchievementResult { AchievementId = achievement.Id, Status = AchievementStatus.Available });
        continue;
    }

    // ===== НИЧЕГО НЕ ВЫПОЛНЕНО =====
    result.Add(new AchievementResult
    {
        AchievementId = achievement.Id,
        Status = AchievementStatus.Locked
    });
}
