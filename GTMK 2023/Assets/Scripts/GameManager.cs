using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private string[] firstName = {
        "Larry", "Marcia", "Pedro", "Agamenon", "Godofredo", "Epaminondas",
        "Astérios" , "Gaspar", "Katarine", "Parnasia", "Anisia", "Hermelia", 
        "Helio", "Euclides", "Atlas", "Michael", "Mayura", "Alecio", "Agnes",
        "Leinad", "Mauro", "Barnabé", "Eduardo", "Cristiano", "Estevao", "Adenilson",
        "Microft", "Miles", "Miguel", "Aparecida", "Teobaldo", "Mark", "Anna", "Luciana",
        "Leonardo", "Dario", "Cleiton", "Marilia", "Sofia", "Clemence", "Clotilde", "Samir",
        "Sebastian", "Salocin", "Onairam", "Emilio", "Isadora", "Thomas", "Paulo",
        "Caio", "Luigi", "Fabrício", "Gale", "Janaina", "Jonathan", "Christopher",
        "Vincent", "Mohamed", "Arthur", "Lex", "Mariano", "Mario", "Felipe", "Rafael",
        "Marcelo", "Speed", "Inigo", "James", "Guy", "Pedro", "Vitor"
    };  

    private string[] lastName = {
        "De Aguiar", "Rubinger", "Lee", "Braverman", "Lima", "Nani", "De Oliveira",
        "Monteiro", "De Carvalho", "McDwedward", "Leite", "Pinto", "McRock", "Rolando",
        "Fischback", "Limeira", "Johnson", "Noe", "McDaniel", "da Costa", "Silva",
        "Bernardes", "Junior", "Filho", "Magalhães", "Marques", "Ribeiro", "Antunes",
        "Pines", "Teixeira", "Nimoy", "Ford", "Hitchcock", "Hidenberg", "Bandeira", "Stark",
        "Lannister", "Baratheon", "Greyjoy", "Massa", "Morales", "O'hara", "Parker", "Bay",
        "Emmerich", "Freeman", "Brasil", "Bowser", "Kirk", "Kenobi", "McAlister", 
        "Bond", "Shark", "Inacio", "Carvalho", "Montoya", "Waterson", "Newell"
    };

    private string[] messagesDoctor = {
        "A real hero for their friends and many others. Saved as many lives as possible.. It's a shame they slipped in a bar of soap and hit their head in the sink.",
        "If it weren’t for the lost scalpel incident, they might have won Health Agent of The Year. But they never found it. Bryan is ok though. However, he says it does hurt When he sneezes. Anyway, such a terrible loss.",
        "Some said they were a little unprofessional with the medicine handling. But I’m sure too much morphine was never bad for anyone. Anyway, should have watched out for that submarine.",
        "They said they would find the secret formula of immortality. I guess they didn’t…",
        "Meredith Grey you owe me one."
    };

    private string[] messagesLawyer = {
        "They stayed nights awake reading and reading and writing and writing, waiting for some time when they could finally rest. The day has come.",
        "They were guilty of loving their job too much.",
        "Sending bad people to prison is always a pleasure. Until they get out",
        "Being a lawyer was not like “Suits” made it seem….",
        "Their dream was to work with crime. Getting money from divorces wasn't bad though.",
        "This guy actually sucked, not gonna lie."
    };

    private string[] messagesMechanic = {
        "They were always up for an oil change. No matter the occasion, they always made my engine run. I’ll never forget the day they put my backdoor right in place.",
        "Ka-chow.",
        "You are not Vin Diesel, you are stupid. No one can hold an entire engine with one arm. NO ONE.",
        "There was nothing they loved more than that car. Ironic they both passed together..",
        "They never let my beetle engine explode, and for that I will always be so grateful.",
        "How the heck did they manage to get the screwdriver stuck in there?"
    };

    private string[] messagesOldman = {
        "They went to all of his ex`s funerals. There was none left in theirs..",
        "'When I die I don't want people to stay all crying. Cry a little and then sing beautiful songs in my memory'",
        "I guess they were too much of a blue pill after all. Went too hard… at least they died happy...",
        "Oops I did it again..",
        "They had the best stories. I will never forget the one when they and their partner decided, already in an advanced age, that hula hooping would be the ideal hobby for them. The hula would always fall, but they had fun!!"
    };

    private string[] messagesKid = {
        "Their first word was c#@*!.",
        "We both know that anything in here would be very sad, so it's just better… not…. you know?",
        "You had to swallow the blender, didn’t you?",
        "It was too much meteor for their little body to handle.",
        "I said to stay away from the battery fluid.",
        "WRENCHES. ARE NOT. EDIBLE."
    };

    public string GenerateFirstName(){
        int index = Random.Range(0, firstName.Length);
        return firstName[index];
    }

    public string GenerateLastName(){
        int index = Random.Range(0, lastName.Length);
        return lastName[index];
    }

    public string GenerateMessage(RaiseTheDead.jobs job){
        int index;
        string message;

        switch(job){
            case RaiseTheDead.jobs.DOCTOR:
                index = Random.Range(0, messagesDoctor.Length);
                message = messagesDoctor[index];
                break;
            case RaiseTheDead.jobs.LAWYER:
                index = Random.Range(0, messagesLawyer.Length);
                message = messagesLawyer[index];
                break;
            case RaiseTheDead.jobs.MECHANIC:
                index = Random.Range(0, messagesMechanic.Length);
                message = messagesMechanic[index];
                break;
            case RaiseTheDead.jobs.OLDMAN:
                index = Random.Range(0, messagesOldman.Length);
                message = messagesOldman[index];
                break;
            case RaiseTheDead.jobs.KID:
            default:
                index = Random.Range(0, messagesKid.Length);
                message = messagesKid[index];
                break;
        }
        
        return message;
    }

    public string GenerateDate(RaiseTheDead.jobs job){
        int maxAge = 70;
        int minAge = 25;
        if(job == RaiseTheDead.jobs.KID){
            maxAge = 11;
            minAge = 2;
        }
        if(job == RaiseTheDead.jobs.OLDMAN){
            maxAge = 100;
            minAge = 75;
        }

        int age = Random.Range(minAge, maxAge);
        int birthYear = Random.Range(1800, 2023 - maxAge);
        int deathYear = birthYear + age;

        int birthMonth = Random.Range(1, 13);
        int deathMonth = Random.Range(1, 13);

        int birthDay = Random.Range(1, 32);
        int deathDay = Random.Range(1, 32);

        string birthDate = birthDay.ToString() + "/" + birthMonth.ToString() + "/" + birthYear.ToString();
        string deathDate = deathDay.ToString() + "/" + deathMonth.ToString() + "/" + deathYear.ToString();
        string date = birthDate + " - " + deathDate;
        return date;
    }

}
