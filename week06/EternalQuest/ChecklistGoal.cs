using System;

class ChecklistGoal : Goal
{
    private int _target;
    private int _completed;
    private int _bonus;

    public ChecklistGoal(string name, string description, int points, int target, int bonus, int completed = 0)
        : base(name, description, points)
    {
        _target = target;
        _bonus = bonus;
        _completed = completed;
    }

    public override int RecordEvent()
    {
        if (_completed < _target)
        {
            _completed++;
            
            if (_completed == _target)
            {
                // Celebration message for bonus
                Console.WriteLine($"\n🎉🎉🎉 BONUS! +{_bonus} points for completing '{_name}'! 🎉🎉🎉\n");
                return _points + _bonus;
            }
            return _points;
        }
        return 0;
    }

    public override bool IsComplete() => _completed >= _target;

    public override string GetDetails()
    {
        string checkbox = IsComplete() ? "[X]" : "[ ]";
        return $"{checkbox} {_name} ({_description}) -- Completed {_completed}/{_target}";
    }

    public override string GetStringRepresentation()
    {
        return $"Checklist|{_name}|{_description}|{_points}|{_bonus}|{_target}|{_completed}";
    }
}